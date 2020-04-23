using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Shop
{
    public class ProductModel : PageModel
    {
        public int ID { get; set; }
        public void OnGet()
        {

        }
    }
}
