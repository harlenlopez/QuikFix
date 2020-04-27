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

        /// <summary>
        ///  using the database context
        /// </summary>
        /// <param name="context">context of the databas</param>
        public ProductService(StoreDbContext context)
        {
            _context = context;

        }

        /// <summary>
        /// To create a product
        /// </summary>
        /// <param name="inventory">product that user wants to add to the database</param>
        /// <returns>product that has been created</returns>
        public async Task<Product> CreateInventory(Product inventory)
        {
            _context.Products.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        /// <summary>
        /// Delete route for product
        /// </summary>
        /// <param name="product">product that will be deleted</param>
        public async Task DeleteInventories(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Getting all of our products in the database
        /// </summary>
        /// <returns>list of products</returns>
        public async Task<List<Product>> GetAllInventories() => await _context.Products.ToListAsync();

        /// <summary>
        /// getting a product specific to the id
        /// </summary>
        /// <param name="ID">id of the product to be query</param>
        /// <returns>product</returns>
        public async Task<Product> GetInventoryById(int ID) => await _context.Products.FindAsync(ID);

        /// <summary>
        /// Update method for product route
        /// </summary>
        /// <param name="product">product that is being updated</param>
        /// <returns>product</returns>
        public async Task<Product> UpdateInventories(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
