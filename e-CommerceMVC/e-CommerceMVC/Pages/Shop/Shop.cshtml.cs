using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Products
{
    public class ShopModel : PageModel
    {
        private readonly IProductManager _product;

        public ShopModel(IProductManager product)
        {
            _product = product;
        }

        public void OnGet()
        {
        }
    }
}
