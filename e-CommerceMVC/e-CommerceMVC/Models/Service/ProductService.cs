using ECommerceMVC.Data;
using ECommerceMVC.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    public class ProductService : IProductManager
    {
        private readonly StoreDbContext _context;

        public ProductService(StoreDbContext context)
        {
            _context = context;

        }

        public async Task<Product> CreateInventory(Product inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task DeleteInventories(Product product)
        {
            _context.Inventories.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllInventories() => await _context.Inventories.ToListAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<Product> GetInventoryById(int ID) => await _context.Inventories.FindAsync(ID);

        /// <summary>
        /// Update method for product route
        /// </summary>
        /// <param name="product">product that is being updated</param>
        /// <returns>product</returns>
        public async Task<Product> UpdateInventories(Product product)
        {
            _context.Inventories.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
