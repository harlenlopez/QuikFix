using ECommerceMVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    // class that will up hold all of the roles
    public class RoleInitializer
    {
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = ApplicationRoles.Member, NormalizedName = ApplicationRoles.Member.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{ Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{ Name = ApplicationRoles.Dev, NormalizedName = ApplicationRoles.Dev.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        /// <summary>
        ///  Seeding the roles into our database using the service provider which is like traffic cop
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var DbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                DbContext.Database.EnsureCreated();
                AddRoles(DbContext);
            }
        }

        // checking to see if there is a role other wise will add it
        private static void AddRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any()) return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();

            }
        }
    }
}
