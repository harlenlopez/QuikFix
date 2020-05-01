﻿using ECommerceMVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    public class RoleInitializer
    {
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = ApplicationRoles.Member, NormalizedName = ApplicationRoles.Member.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{ Name = ApplicationRoles.Admin, NormalizedName = ApplicationRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{ Name = ApplicationRoles.Dev, NormalizedName = ApplicationRoles.Dev.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var DbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                DbContext.Database.EnsureCreated();
                AddRoles(DbContext);
            }
        }

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
