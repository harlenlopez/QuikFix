using ECommerceMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   ID = 1,
                   SKU = "8fj38s10",
                   Name = "modern",
                   Description = "very modern dumpster fires",
                   Image = "",
                   Price = 200.00m,
                   
               },
               new Product
               {
                   ID = 2,
                   SKU = "8fw4s10",
                   Name = "hipster",
                   Description = "very hipster dumpster fires",
                   Image = "",
                   Price = 300.00m,

               },
                new Product
                {
                    ID = 3,
                    SKU = "4nj38s10",
                    Name = "antique",
                    Description = "very antique dumpster fires",
                    Image = "",
                    Price = 180.00m,

                },
                new Product
                {
                    ID = 4,
                    SKU = "7mj38s10",
                    Name = "comic",
                    Description = "very comical dumpster fires",
                    Image = "",
                    Price = 210.00m,

                },
                new Product
                {
                    ID = 5,
                    SKU = "12j38s10",
                    Name = "nature",
                    Description = "very natural dumpster fires",
                    Image = "",
                    Price = 2000.00m,

                },
                new Product
                {
                    ID = 6,
                    SKU = "8fg38s10",
                    Name = "technical",
                    Description = "very technical dumpster fires",
                    Image = "",
                    Price = 200.00m,

                },
               new Product
               {
                   ID = 7,
                   SKU = "8fw8s10",
                   Name = "greyscale",
                   Description = "very drab dumpster fires",
                   Image = "",
                   Price = 75.00m,

               },
                new Product
                {
                    ID = 8,
                    SKU = "yv538s10",
                    Name = "cozy",
                    Description = "very cozy dumpster fires",
                    Image = "",
                    Price = 240.00m,

                },
                new Product
                {
                    ID = 9,
                    SKU = "83nd8fn3",
                    Name = "colorful",
                    Description = "very colorful dumpster fires",
                    Image = "",
                    Price = 350.00m,

                },
                new Product
                {
                    ID = 10,
                    SKU = "12jrj830",
                    Name = "classic",
                    Description = "very classic dumpster fires",
                    Image = "",
                    Price = 150.00m,

                }
                );
        }

        public DbSet<Product> Inventories { get; set; }

    }
}
