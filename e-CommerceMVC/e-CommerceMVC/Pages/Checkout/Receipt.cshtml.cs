using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using ECommerceMVC.Models.ViewModel;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceMVC.Pages.Checkout
{
    public class ReceiptModel : PageModel
    {
        /// <summary>
        /// Local properties
        /// </summary>
        private readonly ICartManager _CartManager;
        private readonly ICartItemsManager _CartItemsManager;
        private readonly IEmailSender _Email;

        //public ReceiptViewModel ReceiptInfo { get; set; }

        /// <summary>
        /// Constructor that brings in all of the interface
        /// </summary>
        /// <param name="cartManager">interface for cart</param>
        /// <param name="cartItemsManager">interface for the cart items</param>
        /// <param name="email">interface for the email sender</param>
        public ReceiptModel(ICartManager cartManager, ICartItemsManager cartItemsManager, IEmailSender email)
        {
            _CartManager = cartManager;
            _CartItemsManager = cartItemsManager;
            _Email = email;

        }

        /// <summary>
        /// Total price of user products
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Get method that will render page and also run the asynchronous method in the back.
        /// </summary>
        public async Task OnGet()
        {
            //ReceiptInfo = rm;
            // Refactoring the method to be more readable code
            await ReceiptDelete();
        }

        /// <summary>
        /// Deleting the cart items as soon as user's done with their purchase
        /// </summary>
        public async Task ReceiptDelete()
        {
            var userName = User.Identity.Name;
            var userId = await _CartManager.GetCartById(userName);
            List<CartItems> CartItems = await _CartManager.GetProductByCartID(userId.ID);
            TempData["ListOfProduct"] = CartItems;
            foreach (var item in CartItems)
            {

                decimal TempTotal = item.Product.Price * item.Quantity;
                TotalPrice += TempTotal;
                await _CartItemsManager.DeleteCartItems(item.ID);
            }

            /// Creating a letter to send it to user when they purchase
            StringBuilder sb = new StringBuilder();

            string imageUrl = "https://i.imgur.com/rocGIxN.png";
            sb.AppendLine($"<div style='text-align:center'>");
            sb.AppendLine($"<img src='{imageUrl}' alt='Logo' style='margin-bottom:50px' />");
            sb.AppendLine("<h3 style='margin-bottom:15px'>Receipt</h3>");


            sb.AppendLine($"<div style='text-align:center; margin-top:80px'>");
            foreach (var item in CartItems)
            {
                sb.AppendLine($"<h5>{item.Product.Name} </h5>");
                sb.AppendLine($"<p>Price: {item.Product.Price} </p>");
                sb.AppendLine($"<p>Quantity: {item.Quantity} </p>");
                sb.AppendLine("<hr />");
            }
            sb.AppendLine($"<p>Total: {TotalPrice} </p>");
            sb.AppendLine($"<p>Thank you for the purchase!</p>");
            sb.AppendLine($"<p>We will start on it right away! </p>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            
            /// sending the receipt to the shopper
            await _Email.SendEmailAsync(userName, "Thank you for the order", sb.ToString());
        }
    }
}
