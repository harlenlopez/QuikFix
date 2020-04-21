using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    /// <summary>
    /// Create, Read, Update, Delete
    /// </summary>
    interface IProductManager
    {
        Task<List<Product>> GetInventoryById(int ID);
        Task<Product> CreateInventory(Product inventory);
        Task<List<Product>> GetAllInventories();
        Task UpdateInventories(Product inventory);
        Task DeleteInventories(int ID);

    }
}
