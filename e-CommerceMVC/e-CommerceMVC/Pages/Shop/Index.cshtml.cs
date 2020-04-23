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
        private readonly IProductManager _product;

        public IndexModel(IProductManager product)
        {
            _product = product;
        }

        public List<Product> ProductList { get; set; }

        public async Task OnGet()
        {
            ProductList = await _product.GetAllInventories();
        }
    }
}
