using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models;
using ECommerceMVC.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _SignInManager;
        [BindProperty]
        public LoginViewModel Input { get; set; }

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _SignInManager = signInManager;

        }
        public void OnGet()
        {
        }

        /// <summary>
        /// Post method that will have logging in the user when they are sign in, if info is not correct redirect them to this page
        /// </summary>
        /// <returns>Either to the main page or back to login page</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _SignInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "you done messed up Aaron");
                    return Page();

                }
            }
            // if this hits it will be back to our login page
            return Page();
        }
    }
}
