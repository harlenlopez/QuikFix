using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Shop
{
    public class ProductModel : PageModel
    {
        /// <summary>
        /// implementing interface.
        /// </summary>
        private readonly IProductManager _ProductManager;
        private readonly ICartManager _CartManager;
        private readonly ICartItemsManager _CartItemManager;

        public Product Product { get; set; }

        /// <summary>
        /// Constructor for introducing interface
        /// </summary>
        /// <param name="productManager"></param>
        public ProductModel(IProductManager productManager, ICartManager cartManager, ICartItemsManager cartItemsManager)
        {
            _ProductManager = productManager;
            _CartManager = cartManager;
            _CartItemManager = cartItemsManager;
        }
        /// <summary>
        /// Getting the website and using the interface to access database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task OnGet(int ID)
        {
            Product = await _ProductManager.GetInventoryById(ID);
        }

        /// <summary>
        /// On post method that will add cart item to the cartitems 
        /// </summary>
        /// <param name="productID">Id of the product</param>
        /// <returns>to the shop index page</returns>
        public async Task<IActionResult> OnPost(int productID)
        {
            var user = User.Identity.Name;
            var userId = await _CartManager.GetCartById(user);
            CartItems cartItems = new CartItems()
            {
                CartsID = userId.ID,
                ProductID = productID,
                Quantity = 1
            };
            await _CartItemManager.CreateCartItems(cartItems);
            return RedirectToPage("/shop/index");
        }
    }
}
