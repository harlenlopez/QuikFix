using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    /// <summary>
    /// Model for indentity db context
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string FavoriteColor { get; set; }
        public string Theme { get; set; }
        public string TypeOfBusiness { get; set; }

    }

    /// <summary>
    /// List of roles that will be available to different users
    /// </summary>
    public static class ApplicationRoles
    {
        public const string Member = "Member";
        public const string Admin = "Admin";
        public const string Dev = "Dev";
    }

}
