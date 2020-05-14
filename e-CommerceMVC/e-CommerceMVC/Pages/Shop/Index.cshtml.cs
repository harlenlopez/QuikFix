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
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Interface
        /// </summary>
        private readonly IProductManager _product;

        /// <summary>
        /// Constructor that brings in the interface
        /// </summary>
        /// <param name="product">product manager interface</param>
        public IndexModel(IProductManager product)
        {
            _product = product;
        }

        //using it to grab a all of the product
        public List<Product> PageList { get; set; }

        //page number variable
        [BindProperty(SupportsGet = true)]
        public int P { get; set; } = 1;

        //page size variable
        [BindProperty(SupportsGet = true)]
        public int S { get; set; } = 6;

        //amount that is in the page
        public int TotalRecords { get; set; }

        // grabbing a product from the database and creating a pagination
        public async Task OnGet()
        {
            List<Product> ProductList = await _product.GetAllInventories();

            TotalRecords = ProductList.Count;

            PageList = ProductList
                .Skip((P - 1) * S)
                .Take(S)
                .ToList();
        }
    }
}
