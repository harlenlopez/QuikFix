using ECommerceMVC.Data;
using ECommerceMVC.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    public class OrderService : IOrderManager
    {
        // local property that stores object of storedbcontext
        private readonly StoreDbContext _context;

        // bringing in the storedbcontext and store it in the local object property
        public OrderService(StoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Create a order using orderlist object
        /// </summary>
        /// <param name="orderList">Orderlist Object</param>
        public async Task CreateOrder(OrderList orderList)
        {
            _context.OrderList.Add(orderList);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete order from orderlist database
        /// </summary>
        /// <param name="ID">id of the orderlist</param>
        public async Task DeleteOrder(int ID)
        {
            var order = await _context.OrderList.FindAsync(ID);
            _context.OrderList.Remove(order);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all of the orders from the database
        /// </summary>
        /// <returns> all of the orders</returns>
        public async Task<List<OrderList>> GetAllOrder() => await _context.OrderList.ToListAsync();

        /// <summary>
        /// Getting a order by its ide
        /// </summary>
        /// <param name="ID">order id</param>
        /// <returns>order object that matches id</returns>
        public async Task<List<OrderList>> GetOrderByID(int ID) => await _context.OrderList.Where(x => x.CartsID == ID).ToListAsync();

        /// <summary>
        /// Random generator for order number to be assigned up user's purchase
        /// </summary>
        /// <returns>randomly generated number from 0-1000000</returns>
        public int OrderNumberGenerator()
        {
            Random random = new Random();

            int randomeNumber = random.Next(100000);

            return randomeNumber;
        }

        /// <summary>
        /// Getting the order using user's id
        /// </summary>
        /// <param name="ID">using id of the user</param>
        /// <returns>all of the order purchase by user</returns>
        public async Task<List<OrderList>> GetOrdersByUserID(int ID)
        {
            var orderList = await _context.OrderList.Where(x => x.CartsID == ID).ToListAsync();

            return orderList;
        }
    }
}
