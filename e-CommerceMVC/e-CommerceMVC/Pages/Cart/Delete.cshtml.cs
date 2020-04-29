using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Data;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Pages.Cart
{
    public class DeleteModel : PageModel
    {
        /// <summary>
        /// Bring in the ICartItemManager interface
        /// </summary>
        private readonly ICartItemsManager _cartItemsManager;
        private readonly ICartManager _cartManager;
        private readonly StoreDbContext _context;

        /// <summary>
        /// Deleting whats in the cart
        /// </summary>
        /// <param name="cartItemsManager"></param>
        public DeleteModel(ICartItemsManager cartItemsManager, ICartManager cartManager, StoreDbContext context)
        {
            _cartItemsManager = cartItemsManager;
            _cartManager = cartManager;
            _context = context;
        }

        /// <summary>
        /// Rerouting to the cart after its been deleted
        /// </summary>
        /// <param name="ID">ID of the item to be deleted</param>
        /// <returns>Cart page</returns>
        public async Task<IActionResult> OnGet(int ID)
        {
            var user = User.Identity.Name;
            var userId = await _cartManager.GetCartById(user);
            var product = await _context.CartItems.Where(x => x.ProductID == ID && x.CartsID == userId.ID).SingleAsync();

            await _cartItemsManager.DeleteCartItems(product.ID);
            return RedirectToPage("/Cart/Index");
        }
    }
}
