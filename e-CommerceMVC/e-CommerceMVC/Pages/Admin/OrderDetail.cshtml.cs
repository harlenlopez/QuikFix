using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Admin
{
    public class OrderDetailModel : PageModel
    {
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;

        public OrderDetailModel(IOrderManager orderManager, IProductManager pManager)
        {
            _orderManager = orderManager;
            _productManager = pManager;
        }

        public List<OrderList> Order { get; set; } 
        public List<Product> OrderProduct { get; set; }

        public async Task OnGet(int id)
        {
            Order = await _orderManager.GetOrderByID(id);
            foreach (var product in Order)
            {
                var result = await _productManager.GetInventoryById(product.ProductID);
                OrderProduct.Add(result);
            }
        }
    }
}
