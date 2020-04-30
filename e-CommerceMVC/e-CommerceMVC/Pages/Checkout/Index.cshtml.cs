using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public UserInfo Userinfo { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            
        }

        public class UserInfo
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Shipping Address")]
            public string ShippingAddress { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            [Display(Name = "State/Province")]
            public string State { get; set; }

            [Required]
            public string Country { get; set; }

            [Required]
            [Display(Name = "Payment Method")]
            public string PaymentMethod { get; set; }

        }
    }

}
