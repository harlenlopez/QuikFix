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
        private readonly IProductManager _ProductManager;
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
        public IndexModel(IProductManager productManager, ICartManager cartManager, ICartItemsManager cartItemsManager, StoreDbContext context)
        {
            _ProductManager = productManager;
            _CartManager = cartManager;
            _Context = context;
            _CartItemsManager = cartItemsManager;
        }

        /// <summary>
        /// Properties that will store data from database
        /// </summary>
        [BindProperty]
        public int Qty { get; set; }
        [BindProperty]
        public int ProductID { get; set; }

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
            ListCart = await _Context.CartItems.Where(x => x.CartsID == userId.ID).ToListAsync();
            foreach (var item in ListCart)
            {
                var pro = await _ProductManager.GetInventoryById(item.ProductID);
                item.Product = pro;
            }

        }

        /// <summary>
        /// Post method that will update the product quantity
        /// </summary>
        /// <returns>redirect to cart page after the update</returns>
        public async Task<IActionResult> OnPost()
        {
            if (Qty <= 0)
            {
                return Page();
            }

            
            var product = await _Context.CartItems.Where(x => x.ProductID == ProductID).SingleAsync();

            product.Quantity = Qty;

            await _CartItemsManager.UpdateCartItems(product);

            return RedirectToPage("Index");
        }
    }
}
