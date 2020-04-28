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
        private readonly IProductManager _ProductManager;
        private readonly ICartManager _CartManager;
        private readonly StoreDbContext _Context;
        private readonly ICartItemsManager _CartItemsManager;

        public IndexModel(IProductManager productManager, ICartManager cartManager, ICartItemsManager cartItemsManager, StoreDbContext context)
        {
            _ProductManager = productManager;
            _CartManager = cartManager;
            _Context = context;
            _CartItemsManager = cartItemsManager;
        }

        [BindProperty]
        public int Qty { get; set; }
        [BindProperty]
        public int ProductID { get; set; }

        public List<CartItems> ListCart { get; set; }

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
