using ECommerceMVC.Data;
using ECommerceMVC.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    public class OrderService : IOrderManager
    {
        private readonly StoreDbContext _context;

        public OrderService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task CreateOrder(OrderList orderList)
        {
            _context.OrderList.Add(orderList);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int ID)
        {
            var order = await _context.OrderList.FindAsync(ID);
            _context.OrderList.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderList>> GetAllOrder() => await _context.OrderList.ToListAsync();
                
    }
}
