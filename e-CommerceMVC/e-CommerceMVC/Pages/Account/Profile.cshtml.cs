using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Account
{
    public class ProfileModel : PageModel
    {
        private readonly ICartManager _cartManager;
        private readonly UserManager<ApplicationDbContext> _userManager;

        [BindProperty]
        public UserPassword UserInfo { get; set; }

        public ProfileModel(ICartManager cManager, UserManager<ApplicationDbContext> userManager)
        {
            _cartManager = cManager;
            _userManager = userManager;
        }
        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            var user = User.Identity.Name;
            var loginUser = await _userManager.FindByIdAsync(user);


        }


        public class UserPassword
        {
            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long", MinimumLength = 8)]
            [DataType(DataType.Password)]
            public string PreviousPassword { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long", MinimumLength = 8)]
            [DataType(DataType.Password)]
            public string ChangePassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("ChangePassword", ErrorMessage = "Password does not match")]
            public string ConfirmPassword { get; set; }
        }
    }
}
