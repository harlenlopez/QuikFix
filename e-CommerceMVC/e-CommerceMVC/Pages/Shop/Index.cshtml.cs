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

        public List<Product> PageList { get; set; }

        //page number variable
        [BindProperty(SupportsGet = true)]
        public int P { get; set; } = 1;

        //page size variable
        [BindProperty(SupportsGet = true)]
        public int S { get; set; } = 6;

        public int TotalRecords { get; set; }

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
