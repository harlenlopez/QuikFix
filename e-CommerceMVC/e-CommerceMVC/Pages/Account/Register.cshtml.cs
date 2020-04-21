using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public RegisterInfo RegisterData { get; set; }
        public void OnGet()
        {
        }

        public class RegisterInfo
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Birth day")]
            public string BirthDay { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long", MinimumLength = 8)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Password does not match")]
            public string ConfirmPassword { get; set; }
        }
    }
}
