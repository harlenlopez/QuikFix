using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    public interface IOrderManager
    {
        Task CreateOrder(OrderList orderList);
        Task<List<OrderList>> GetAllOrder();
        Task DeleteOrder(int ID);
    }
}
