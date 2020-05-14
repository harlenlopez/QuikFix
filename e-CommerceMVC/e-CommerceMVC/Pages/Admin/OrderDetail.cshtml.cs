using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class OrderDetailModel : PageModel
    {
        private readonly IProductManager _productManager;
        private readonly StoreDbContext _context;

        /// <summary>
        /// bringing in the interface to be used in this class
        /// </summary>
        public OrderDetailModel(IProductManager pManager, StoreDbContext context)
        {
            _productManager = pManager;
            _context = context;
        }
        // storing all of the information from the database to be used in the html.
        public List<OrderList> Order { get; set; }
        public List<Product> OrderProduct = new List<Product>();

        /// <summary>
        /// Getting all of the ordernumber and sorting them so we don't have duplicate order
        /// </summary>
        /// <param name="ordernumber"> Order number</param>
        /// <returns></returns>
        public async Task OnGet(int ordernumber)
        {
            Order = await _context.OrderList.Where(x => x.OrderNumber == ordernumber).ToListAsync();
            foreach (var product in Order)
            {
                var result = await _productManager.GetInventoryById(product.ProductID);
                OrderProduct.Add(result);
            }
        }
    }
}
