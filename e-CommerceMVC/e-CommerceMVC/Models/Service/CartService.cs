using ECommerceMVC.Data;
using ECommerceMVC.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    /// <summary>
    /// Cart service that implements ICartmanager interface
    /// </summary>
    public class CartService : ICartManager
    {
        /// <summary>
        ///  using local properties to be used in this service class
        /// </summary>
        private readonly StoreDbContext _context;
        private readonly IProductManager _productManager;

        /// <summary>
        /// Constructor that will brining in dbcontext and interface
        /// </summary>
        /// <param name="context"></param>
        /// <param name="productManager"></param>
        public CartService(StoreDbContext context, IProductManager productManager)
        {
            _context = context;
            _productManager = productManager;
        }
        /// <summary>
        /// Creating the user to cart database
        /// </summary>
        /// <param name="carts">cart object</param>
        public async Task<Carts> CreateCart(Carts carts)
        {
            _context.Cart.Add(carts);
            await _context.SaveChangesAsync();
            return carts;
        }

        /// <summary>
        /// getting a user by email
        /// </summary>
        /// <param name="email">email that was used to sign up</param>
        public async Task<Carts> GetCartById(string email)
        {
            var carts = await _context.Cart.Where(x => x.Email == email).SingleAsync();
            return carts;
        }

        //Getting the products using the cart id
        public async Task<List<CartItems>> GetProductByCartID(int id)
        {
            List<CartItems> cartList = await _context.CartItems.Where(x => x.CartsID == id).ToListAsync();
            foreach (var item in cartList)
            {
                var pro = await _productManager.GetInventoryById(item.ProductID);
                item.Product = pro;
            }

            return cartList;
        }
        
    }
}
