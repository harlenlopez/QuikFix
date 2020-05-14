using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Components
{
    public class ShoppingCart : ViewComponent
    {
        // local property
        private readonly StoreDbContext _context;

        //Constructor that bring in the dbcontext
        public ShoppingCart(StoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The tally of all of the item in the cart
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// A view component method that will be used to grab all of the item in the cart
        /// </summary>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = User.Identity.Name;
            var user = _context.Cart.Where(x => x.Email == userName).Single();
            var cartList = await _context.CartItems.Where(x => x.CartsID == user.ID).ToListAsync();

            foreach (var list in cartList)
            {
                var pro = await _context.Products.Where(x => x.ID == list.ProductID).SingleAsync();
                list.Product = pro;
                decimal TempTotal = list.Quantity * list.Product.Price;
                TotalPrice += TempTotal;
            }
            return View(cartList);
        }

    }
}
