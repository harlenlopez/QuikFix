using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Pages.Cart
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Interface and database context and interfaces
        /// </summary>
        private readonly ICartManager _CartManager;
        private readonly StoreDbContext _Context;
        private readonly ICartItemsManager _CartItemsManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productManager">interface for product</param>
        /// <param name="cartManager">interface for cart</param>
        /// <param name="cartItemsManager">interface for cart item</param>
        /// <param name="context">dbcontext context</param>
        public IndexModel(ICartManager cartManager, ICartItemsManager cartItemsManager, StoreDbContext context)
        {
            _CartManager = cartManager;
            _Context = context;
            _CartItemsManager = cartItemsManager;
        }

        /// <summary>
        /// Properties that will store data from database
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Storing items in the cart
        /// </summary>
        public List<CartItems> ListCart { get; set; }

        /// <summary>
        /// Get method that query the database for products
        /// </summary>
        public async Task OnGet()
        {
            var userName = User.FindFirstValue(ClaimTypes.Email);
            var userId = await _CartManager.GetCartById(userName);
            ListCart = await _CartManager.GetProductByCartID(userId.ID);
            foreach (var item in ListCart)
            {
                decimal TempTotal = item.Product.Price * item.Quantity;
                TotalPrice += TempTotal;
            }
        }

        /// <summary>
        /// Post method that will update the product quantity
        /// </summary>
        /// <returns>redirect to cart page after the update</returns>
        public async Task<IActionResult> OnPost(int productID,int quantity)
        {
            if (quantity <= 0)
            {
                return Page();
            }
            var user = User.Identity.Name;

            var userId = await _CartManager.GetCartById(user);

            var product = await _Context.CartItems.Where(x => x.ProductID == productID && x.CartsID == userId.ID).SingleAsync();

            product.Quantity = quantity;

            await _CartItemsManager.UpdateCartItems(product);

            return RedirectToPage("Index");
        }
    }
}
