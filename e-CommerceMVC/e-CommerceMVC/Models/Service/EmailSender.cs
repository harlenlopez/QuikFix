using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    /// <summary>
    /// Implementing the IEmail sender to the method and having to bringing the built in methods from Microsoft library
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Bringing in the configuration library to be used for private property
        /// </summary>
        /// <param name="configuration"></param>
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Method from the IEMailSender
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="subject">subject of the email</param>
        /// <param name="htmlMessage">content of the email</param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // injecting the api key from sendgrid
            SendGridClient client = new SendGridClient(_configuration["SendGrid-Key"]);
            SendGridMessage msg = new SendGridMessage();

            //First param is email and second is email
            msg.SetFrom("quikfixcf@gmail.com", "QuickFix");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);
        }
    }
}
