using ECommerceMVC.Data;
using ECommerceMVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    public class InventoryService : IInventoryManager
    {
        private readonly StoreDbContext _context;

        public InventoryService(StoreDbContext context)
        {
            _context = context;

        }
        public async Task<Inventory> CreateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInventories(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Inventory>> GetAllInventories()
        {
            throw new NotImplementedException();
        }

        public Task<List<Inventory>> GetInventoryById(int ID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInventories(Inventory inventory)
        {
            throw new NotImplementedException();
        }
    }
}
