using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using ECommerceMVC.Models.ViewModel;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        // Local properties that are being used
        private readonly ICartManager _CartManager;
        private readonly IPayment _payment;

        /// <summary>
        /// Constructor that brings the interface
        /// </summary>
        public IndexModel( ICartManager cartManger, IPayment payment)
        {
            _CartManager = cartManger;
            _payment = payment;
        }

        // User info when they feel out
        [BindProperty]
        public ReceiptViewModel Userinfo { get; set; }

        /// <summary>
        /// Tallying the total price
        /// </summary>
        public decimal TotalPrice { get; set; }

        // List of cartitems
        public List<CartItems> CartItems { get; set; }

        /// <summary>
        /// Calling all getting the cart items for the user
        /// </summary>
        public async Task OnGet()
        {
            await GetData();
        }

        /// <summary>
        /// Submitting the whats in the cart and sending it to the user
        /// </summary>
        /// <returns>Sending the email</returns>
        public async Task<IActionResult> OnPost()
        {
            /// Checking to see if user had filled out right information
            if (ModelState.IsValid) 
            { 
                // Computing
                await GetData();


                /// Using the view models to create an object of customerAddressType to send it through PaymentService
                customerAddressType addressInfo = new customerAddressType
                {
                    firstName = Userinfo.FirstName,
                    lastName = Userinfo.LastName,
                    address = Userinfo.ShippingAddress,
                    city = Userinfo.City,
                    zip = Userinfo.ZipCode.ToString()
                };

                // As the result of Authorize.net payment process, it will return false, if it didn't go through, and it will return true if it did.
                bool result = _payment.Run(addressInfo, TotalPrice);

                // Only routing them back if the payment have processed correctly.
                if (result)
                {
                    // redirect them to receipt page once the payment goes through
                    return RedirectToPage("Receipt", Userinfo);
                }

            }
            // otherwise, it wil reroute them to page
            return Page();
        }

        /// <summary>
        /// Getting what is in the user's cart
        /// </summary>
        public async Task GetData()
        {
            var userName = User.Identity.Name;
            var userId = await _CartManager.GetCartById(userName);
            CartItems = await _CartManager.GetProductByCartID(userId.ID);
            foreach (var item in CartItems)
            {

                decimal TempTotal = item.Product.Price * item.Quantity;
                TotalPrice += TempTotal;
            }
        }
    }

}
