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
        private readonly ICartItemsManager _ItemManager;
        private readonly ICartManager _CartManager;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly StoreDbContext _Context;

        public IndexModel(IProductManager productManager, ICartItemsManager itemsManager, ICartManager cartManager, UserManager<ApplicationUser> userManager, StoreDbContext context)
        {
            _ProductManager = productManager;
            _ItemManager = itemsManager;
            _CartManager = cartManager;
            _UserManager = userManager;
            _Context = context;
        }

        public async Task OnGet()
        {
            var userName = User.FindFirstValue(ClaimTypes.Email);
            var userId = await _CartManager.GetCartById(userName);
            List<CartItems> cartItems = await _Context.CartItems.Where(x => x.CartID == userId.ID).ToListAsync();
            List<Product> product = new List<Product>();
            foreach (var item in cartItems)
            {
                var pro = await _ProductManager.GetInventoryById(item.ProductID);
                product.Add(pro);
            }
        }
    }
}
