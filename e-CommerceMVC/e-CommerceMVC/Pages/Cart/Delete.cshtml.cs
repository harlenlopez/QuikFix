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
        private readonly ICartItemsManager _cartItemsManager;

        public DeleteModel(ICartItemsManager cartItemsManager)
        {
            _cartItemsManager = cartItemsManager;
        }
        public async Task<IActionResult> OnGet(int ID)
        {
            await _cartItemsManager.DeleteCartItems(ID);
            return RedirectToPage("/Cart/Index");
        }
    }
}
