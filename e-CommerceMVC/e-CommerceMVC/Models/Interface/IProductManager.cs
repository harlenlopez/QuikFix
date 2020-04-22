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
        Task<Product> GetInventoryById(int ID);
        Task<Product> CreateInventory(Product inventory);
        Task<List<Product>> GetAllInventories();
        Task<Product> UpdateInventories(Product inventory);
        Task DeleteInventories(Product product);

    }
}
