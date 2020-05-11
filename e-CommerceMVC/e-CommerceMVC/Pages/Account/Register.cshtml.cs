using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly ICartManager _cartManager;
        private readonly IEmailSender _email;

        /// <summary>
        /// Biding user form data to normalize it
        /// </summary>
        [BindProperty]
        public RegisterInfo RegisterData { get; set; }

        // constructor to bringing in identity built in libraries (UserManager and SigninManager)
        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICartManager cartManager, IEmailSender email)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartManager = cartManager;
            _email = email;
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
                    BirthDate = RegisterData.BirthDay,
                    FavoriteColor = RegisterData.FavoriteColor,
                    TypeOfBusiness = RegisterData.TypeOfBusiness,
                    Theme = RegisterData.Theme

                };

                var result = await _userManager.CreateAsync(user, RegisterData.Password);

                if (result.Succeeded)
                {
                    // claim for name of the user
                    Claim name = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    // claim for birthday of the user
                    Claim birthday = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.BirthDate.Year, user.BirthDate.Month, user.BirthDate.Day).ToString("u"), ClaimValueTypes.DateTime);

                    // claim for email of the user
                    Claim email = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    // claim for favorite color of the user
                    Claim color = new Claim("FavoriteColor", user.FavoriteColor);

                    // claim for business of the user owns
                    Claim business = new Claim("TypeOfBusiness", user.TypeOfBusiness);

                    // claim for theme that user wants to make
                    Claim theme = new Claim("Theme", user.Theme);

                    // creating a list of claims and tying it together
                    List<Claim> claims = new List<Claim>()
                    {
                        name, birthday, email, color, theme, business
                    };

                    // adding the claims to the database
                    await _userManager.AddClaimsAsync(user, claims);

                    // creating a cart object to be stored when the user creates email
                    Carts carts = new Carts()
                    {
                        Email = RegisterData.Email
                    };

                    await _cartManager.CreateCart(carts);

                    /// Allowing certain individual to have admin powers
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
                    if (user.Email == "fourstringaddiction@gmail.com" || user.Email == "jinwoov@gmail.com" || user.Email == "rice.jonathanm@gmail.com" || user.Email == "amanda@codefellows.com" || user.Email == "revyolution1120@gmail.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    }
                    if  (user.Email == "fourstringaddiction@gmail.com" || user.Email == "jinwoov@gmail.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Dev);
                    }

                    // Sending Mail to User
                    StringBuilder sb = new StringBuilder();

                    string imageUrl = "https://i.imgur.com/rocGIxN.png";
                    sb.AppendLine($"<div style='text-align:center'>");
                    sb.AppendLine($"<img src='{imageUrl}' alt='Logo' style='margin-bottom:50px' />");
                    sb.AppendLine($"<h3>Thank you so much for signup to QuikFix, {RegisterData.FirstName}</h3>");
                    sb.AppendLine("<p> Let's make your dream come true! </p>");
                    sb.AppendLine("</div>");

                    await _email.SendEmailAsync(RegisterData.Email, "Welcome to the QuikFix", sb.ToString());



                    //signs user in
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
            [Display(Name = "Birthday")]
            public DateTime BirthDay { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long", MinimumLength = 8)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Password does not match")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Your Favorite Color")]
            public string FavoriteColor { get; set; }

            [Required]
            [Display(Name = "What Type of Business Do You Own?")]
            public string TypeOfBusiness { get; set; }

            [Required]
            [Display(Name = "What Type Of Themes Do You Enjoy?")]
            public string Theme { get; set; }
        }
    }
}
