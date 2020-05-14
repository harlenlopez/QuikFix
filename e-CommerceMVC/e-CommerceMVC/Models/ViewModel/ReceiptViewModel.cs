using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.ViewModel
{

    /// <summary>
    /// These information is used for the user's to fill out and will be sent to the auth net which then send confirmation email using the info provided by user to their email.
    /// </summary>
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
