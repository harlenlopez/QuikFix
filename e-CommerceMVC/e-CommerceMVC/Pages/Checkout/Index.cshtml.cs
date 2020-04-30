using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class IndexModel : PageModel
    {
        private readonly IEmailSender _email;
        private readonly ICartManager _CartManager;

        public IndexModel(IEmailSender email, ICartManager cartManger)
        {
            _email = email;
            _CartManager = cartManger;
        }
        [BindProperty]
        public ReceiptViewModel Userinfo { get; set; }

        public decimal TotalPrice { get; set; }

        public List<CartItems> CartItems { get; set; }

        public async Task OnGet()
        {
            await GetData();
        }

        public async Task<IActionResult> OnPost()
        {

            var userName = User.Identity.Name;
            await GetData();
            // Sending Mail to User

            StringBuilder sb = new StringBuilder();

            string imageUrl = "https://i.imgur.com/rocGIxN.png";
            sb.AppendLine($"<div style='text-align:center'>");
            sb.AppendLine($"<img src='{imageUrl}' alt='Logo' style='margin-bottom:50px' />");
            sb.AppendLine("<h3 style='margin-bottom:15px'>Receipt</h3>");
            sb.AppendLine($"<p>First Name: {Userinfo.FirstName} </p>");
            sb.AppendLine($"<p>Last Name: {Userinfo.LastName} </p>");
            sb.AppendLine($"<p>Shipping Address: {Userinfo.ShippingAddress} </p>");
            sb.AppendLine($"<p>City: {Userinfo.City} </p>");
            sb.AppendLine($"<p>State: {Userinfo.State} </p>");
            sb.AppendLine($"<p>Country {Userinfo.Country} </p>");
            sb.AppendLine($"<p>Payment Method: {Userinfo.PaymentMethod} </p>");


            sb.AppendLine($"<div style='text-align:center; margin-top:80px'>");
            foreach (var item in CartItems)
            {
                sb.AppendLine($"<h5>{item.Product.Name} </h5>");
                sb.AppendLine($"<p>Price: {item.Product.Price} </p>");
                sb.AppendLine("<hr />");
            }
            sb.AppendLine($"<p>Total: {TotalPrice} </p>");
            sb.AppendLine($"<p>Thank you, {Userinfo.FirstName} {Userinfo.LastName}!</p>");
            sb.AppendLine($"<p>We will start on it right away! </p>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            
            await _email.SendEmailAsync(userName, "Thank you for the order", sb.ToString());



            return RedirectToPage("Receipt", Userinfo);

        }

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
