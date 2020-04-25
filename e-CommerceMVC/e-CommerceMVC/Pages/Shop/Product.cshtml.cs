using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Shop
{
    public class ProductModel : PageModel
    {
        /// <summary>
        /// implementing interface.
        /// </summary>
        private readonly IProductManager _ProductManager;
        public Product Product { get; set; }

        /// <summary>
        /// Constructor for introducing interface
        /// </summary>
        /// <param name="productManager"></param>
        public ProductModel(IProductManager productManager)
        {
            _ProductManager = productManager;
        }
        /// <summary>
        /// Getting the website and using the interface to access database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task OnGet(int ID)
        {
            Product = await _ProductManager.GetInventoryById(ID);
        }
    }
}
