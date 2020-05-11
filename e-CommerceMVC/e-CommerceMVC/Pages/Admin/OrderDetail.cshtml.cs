using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Pages.Admin
{
    public class OrderDetailModel : PageModel
    {
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;
        private readonly StoreDbContext _context;

        public OrderDetailModel(IOrderManager orderManager, IProductManager pManager, StoreDbContext context)
        {
            _orderManager = orderManager;
            _productManager = pManager;
            _context = context;
        }

        public List<OrderList> Order { get; set; }
        public List<Product> OrderProduct = new List<Product>();

        /// <summary>
        /// Post 
        /// </summary>
        /// <param name="ordernumber"></param>
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
        /// I have to change duplicate list from showing and also change check if the order number is incrementing
    }
}
