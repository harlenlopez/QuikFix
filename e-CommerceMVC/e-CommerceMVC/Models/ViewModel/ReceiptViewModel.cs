using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.ViewModel
{

    // This is created for future use when the user is going to fill out the personal information to checkout
    public class ReceiptViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Display(Name = "State/Province")]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

    }
}
