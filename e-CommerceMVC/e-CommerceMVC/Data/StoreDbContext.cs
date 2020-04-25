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

        /// <summary>
        /// This is used to seed data
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   ID = 1,
                   SKU = "12jrj830",
                   Name = "Classic",
                   Description = "Classic website",
                   Image = "https://i.imgur.com/ex7bvr4.jpg",
                   Price = 150.00m,

               },
               new Product
               {
                   ID = 2,
                   SKU = "8fw4s10",
                   Name = "Hipster",
                   Description = "Hipster website",
                   Image = "https://i.imgur.com/KckYFPo.jpg",
                   Price = 300.00m,

               },
                new Product
                {
                    ID = 3,
                    SKU = "4nj38s10",
                    Name = "Antique",
                    Description = "Antique website",
                    Image = "https://i.imgur.com/rIRLFbX.jpg",
                    Price = 180.00m,

                },
                new Product
                {
                    ID = 4,
                    SKU = "7mj38s10",
                    Name = "Comic",
                    Description = "Comical website",
                    Image = "https://i.imgur.com/xf5nzhK.jpg",
                    Price = 210.00m,

                },
                new Product
                {
                    ID = 5,
                    SKU = "12j38s10",
                    Name = "Nature",
                    Description = "Natural website",
                    Image = "https://i.imgur.com/1k8nogz.jpg",
                    Price = 2000.00m,

                },
                new Product
                {
                    ID = 6,
                    SKU = "8fg38s10",
                    Name = "Technical",
                    Description = "Technical website",
                    Image = "https://i.imgur.com/q1OefoY.jpg",
                    Price = 200.00m,

                },
               new Product
               {
                   ID = 7,
                   SKU = "8fw8s10",
                   Name = "Greyscale",
                   Description = "Greyscale website",
                   Image = "https://i.imgur.com/lJrL4Sr.jpg",
                   Price = 75.00m,

               },
                new Product
                {
                    ID = 8,
                    SKU = "yv538s10",
                    Name = "Cozy",
                    Description = "Cozy website",
                    Image = "https://i.imgur.com/ZesihIk.jpg",
                    Price = 240.00m,

                },
                new Product
                {
                    ID = 9,
                    SKU = "83nd8fn3",
                    Name = "Colorful",
                    Description = "Colorful website",
                    Image = "https://i.imgur.com/26bU5zY.png",
                    Price = 350.00m,

                },
                new Product
                {
                    ID = 10,
                    SKU = "8fj38s10",
                    Name = "Modern",
                    Description = "Modern website",
                    Image = "https://i.imgur.com/G6NxY8n.jpg",
                    Price = 200.00m,
                }
                );
        }

        /// <summary>
        /// Using the dbset of product
        /// </summary>
        public DbSet<Product> Inventories { get; set; }

    }
}
