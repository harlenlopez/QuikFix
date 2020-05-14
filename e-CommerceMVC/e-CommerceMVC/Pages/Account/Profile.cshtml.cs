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
        /// <summary>
        /// Local properties
        /// </summary>
        private readonly IOrderManager _orderManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartManager _cartManager;

        /// <summary>
        ///  Biding users input fill out
        /// </summary>
        [BindProperty]
        public UserPassword UserInfo { get; set; }

        // claims that user during the registration
        public UserPassword Claims = new UserPassword();

        /// <summary>
        /// All of the user's orders are store in this list
        /// </summary>
        public List<OrderList> UserOrderList { get; set; }

        /// <summary>
        /// Constructor to bring interface
        /// </summary>
        public ProfileModel(IOrderManager orderManager, UserManager<ApplicationUser> userManager, ICartManager cartManager)
        {
            _orderManager = orderManager;
            _userManager = userManager;
            _cartManager = cartManager;
        }
        /// <summary>
        /// Onget method to get user's orders and also their claims
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            var user = User.Identity.Name;
            var loginUser = await _userManager.FindByEmailAsync(user);
            Claims.Theme = loginUser.Theme;
            Claims.FavoriteColor = loginUser.FavoriteColor;
            Claims.TypeOfBusiness = loginUser.TypeOfBusiness;

            var userCart = await _cartManager.GetCartById(user);
            UserOrderList = await _orderManager.GetOrdersByUserID(userCart.ID);
            UserOrderList = UserOrderList.GroupBy(x => x.OrderNumber).Select(z => z.First()).OrderBy(x => x.OrderDate).Take(5).ToList();
        }

        /// <summary>
        /// Post method to grab their input fillout and check to to see if user have entered previous password matches, if yes then it will store new password 
        /// </summary>
        /// <returns>if fails goes back to the profile page otherwise goes back to index page</returns>
        public async Task<IActionResult> OnPost()
        {
            var user = User.Identity.Name;

            var loginUser = await _userManager.FindByEmailAsync(user);
            var result = await _userManager.ChangePasswordAsync(loginUser, UserInfo.PreviousPassword, UserInfo.ChangePassword);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
            return RedirectToPage("/Account/Profile", ModelState);

        }

        /// <summary>
        /// User information will stored through this model
        /// </summary>
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

            public string FavoriteColor { get; set; }

            public string Theme { get; set; }

            public string TypeOfBusiness { get; set; }
        }
    }
}
