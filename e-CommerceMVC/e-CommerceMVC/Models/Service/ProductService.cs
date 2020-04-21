using ECommerceMVC.Data;
using ECommerceMVC.Models.Interface;
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
            throw new NotImplementedException();
        }

        public Task DeleteInventories(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllInventories()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetInventoryById(int ID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInventories(Product inventory)
        {
            throw new NotImplementedException();
        }
    }
}
