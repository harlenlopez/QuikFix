using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Cart
{
    public class DeleteModel : PageModel
    {
        /// <summary>
        /// Bring in the ICartItemManager interface
        /// </summary>
        private readonly ICartItemsManager _cartItemsManager;

        /// <summary>
        /// Deleting whats in the cart
        /// </summary>
        /// <param name="cartItemsManager"></param>
        public DeleteModel(ICartItemsManager cartItemsManager)
        {
            _cartItemsManager = cartItemsManager;
        }

        /// <summary>
        /// Rerouting to the cart after its been deleted
        /// </summary>
        /// <param name="ID">ID of the item to be deleted</param>
        /// <returns>Cart page</returns>
        public async Task<IActionResult> OnGet(int ID)
        {
            await _cartItemsManager.DeleteCartItems(ID);
            return RedirectToPage("/Cart/Index");
        }
    }
}
