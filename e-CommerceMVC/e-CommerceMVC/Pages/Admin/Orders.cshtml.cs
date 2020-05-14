using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Admin
{
    /// <summary>
    /// Role set only for admin to access this url
    /// </summary>
    [Authorize(Policy = "AdminOnly")]
    public class OrdersModel : PageModel
    {
        private readonly IOrderManager _orderManager;
        /// <summary>
        /// bringing in the interface to be referenced in this class
        /// </summary>
        /// <param name="oManager">interface object</param>
        public OrdersModel(IOrderManager oManager)
        {
            _orderManager = oManager;
        }
        // storing the order list
        public List<OrderList> OrderList { get; set; }

        // Sorting the list and grabbing only one that is going to be distinct from other orders.
        public async Task OnGet()
        {
            OrderList = await _orderManager.GetAllOrder();
            OrderList = OrderList.GroupBy(x => x.OrderNumber)
                                .Select(z => z.First())
                                .ToList();
        }

    }
}
