using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    /// <summary>
    /// Create, Read, Update, Delete
    /// </summary>
    interface IInventoryManager
    {
        Task<List<Inventory>> GetInventoryById(int ID);
        Task<Inventory> CreateInventory(Inventory inventory);
        Task<List<Inventory>> GetAllInventories();
        Task UpdateInventories(Inventory inventory);
        Task DeleteInventories(int ID);

    }
}
