using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Account
{
    public class RegisterModel : PageModel
    {
        /// <summary>
        /// Local variables
        /// </summary>
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Biding user form data to normalize it
        /// </summary>
        [BindProperty]
        public RegisterInfo RegisterData { get; set; }

        // constructor to bringing in identity built in libraries (UserManager and SigninManager)
        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Get method that will be used to get the page when route is being hit
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Post Method that will grab data from the Register Razor page
        /// </summary>
        /// <returns>To the index page if its successful otherwise back to same page</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = RegisterData.Email,
                    Email = RegisterData.Email,
                    FirstName = RegisterData.FirstName,
                    LastName = RegisterData.LastName,
                    BirthDate = RegisterData.BirthDay
                };

                var result = await _userManager.CreateAsync(user, RegisterData.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "Home");
                }

                // Adding all the error message into model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }

            return Page();
        }

        /// <summary>
        /// Nested class that will be ran to normalize inputs from the page.
        /// </summary>
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
            public DateTime BirthDay { get; set; }

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
