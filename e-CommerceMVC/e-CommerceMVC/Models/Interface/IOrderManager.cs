using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    public interface IOrderManager
    {
        // Create order
        Task CreateOrder(OrderList orderList);
        // Read all order
        Task<List<OrderList>> GetAllOrder();
        // Get one order
        Task<List<OrderList>> GetOrderByID(int ID);
        // get ordernumber by randomly generated 
        int OrderNumberGenerator();
        // Delete order
        Task DeleteOrder(int ID);
        // Get order using user's id
        Task<List<OrderList>> GetOrdersByUserID(int ID);
    }
}
