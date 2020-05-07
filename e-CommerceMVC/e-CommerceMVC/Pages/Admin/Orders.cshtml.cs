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
    public class OrdersModel : PageModel
    {
        private readonly IOrderManager _orderManager;

        public OrdersModel(IOrderManager oManager)
        {
            _orderManager = oManager;
        }

        public List<OrderList> OrderList { get; set; }

        public async Task OnGet()
        {
            OrderList = await _orderManager.GetAllOrder();
            OrderList = OrderList.GroupBy(x => x.OrderDate)
                                .Select(z => z.First())
                                .ToList();
        }

    }
}
