using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AuthorizeNet.Api.Contracts.V1;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using ECommerceMVC.Models.ViewModel;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ECommerceMVC.Pages.Checkout
{
    public class IndexModel : PageModel
    {

        // Local properties that are being used
        private readonly IConfiguration _config;
        private readonly ICartManager _CartManager;
        private readonly IPayment _payment;
        private readonly IOrderManager _orderManager;

        /// <summary>
        /// Constructor that brings the interface
        /// </summary>
        public IndexModel( ICartManager cartManger, IPayment payment, IConfiguration configuration, IOrderManager orderManager)
        {
            _config = configuration;
            _CartManager = cartManger;
            _payment = payment;
            _orderManager = orderManager;
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
                // Computing total price
                await GetData();

                //validating the address using the USPS api
                string response = ValidateAddress();

                // if the return XML contains error, then it will output error message and have user fill out again
                if (response.Contains("Error"))
                {
                    ModelState.AddModelError(String.Empty, "Please Enter Correct Address");
                    return Page();
                }

                int orderNumber = _orderManager.OrderNumberGenerator();

                foreach (var item in CartItems)
                {
                    OrderList orderList = new OrderList
                    {
                        FirstName = Userinfo.FirstName,
                        LastName = Userinfo.LastName,
                        OrderDate = DateTime.Now,
                        TotalPrice = TotalPrice,
                        ProductID = item.ProductID,
                        Quantities = item.Quantity,
                        CartsID = item.CartsID,
                        OrderNumber = orderNumber
                    };
                    await _orderManager.CreateOrder(orderList);
                }


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
            // otherwise, it will reroute them to page
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


        /// <summary>
        /// Method that will be used to create XML format document to be sent off to the USPS and they will validate if its correct address
        /// </summary>
        /// <returns>XML output of correct address or error address</returns>
        public string ValidateAddress()
        {
            /// Creating XDocument to be sent to USPS
            XDocument requestDoc = new XDocument(
                    new XElement("AddressValidateRequest",
                        new XAttribute("USERID", _config["USPSAPI"]),
                        new XElement("Revision", "1"),
                        new XElement("Address",
                            new XAttribute("ID", "0"),
                            new XElement("Address1", Userinfo.ShippingAddress),
                            new XElement("Address2", ""),
                            new XElement("City", Userinfo.City),
                            new XElement("State", Userinfo.State),
                            new XElement("Zip5", Userinfo.ZipCode),
                            new XElement("Zip4", "")
                            )
                        )
                    );
            //API for USPS
            var url = @"https://secure.shippingapis.com/ShippingAPI.dll?API=Verify&XML=" + requestDoc;
            var client = new WebClient();
            var response = client.DownloadString(url);
            return response;
        }
    }

}
