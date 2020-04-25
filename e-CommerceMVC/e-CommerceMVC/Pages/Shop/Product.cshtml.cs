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
        private readonly IProductManager _ProductManager;
        public Product Product { get; set; }
        public ProductModel(IProductManager productManager)
        {
            _ProductManager = productManager;
        }
        public async Task OnGet(int ID)
        {
            Product = await _ProductManager.GetInventoryById(ID);
        }
    }
}
