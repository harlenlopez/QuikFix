using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    /// <summary>
    /// Create, Read, Update, Delete
    /// </summary>
    public interface IProductManager
    {
        // Get by ID
        Task<Product> GetInventoryById(int ID);
        // Create
        Task<Product> CreateInventory(Product inventory);
        // Get all products from the db
        Task<List<Product>> GetAllInventories();
        // Update
        Task<Product> UpdateInventories(Product inventory);
        // Delete
        Task DeleteInventories(Product product);

    }
}
