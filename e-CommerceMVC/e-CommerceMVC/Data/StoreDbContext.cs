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
                   Description = "Website that is tailor to business with exquisite taste in classical theme. This outline will grab all of the antiquity enthusiast ",
                   Image = "https://i.imgur.com/ex7bvr4.jpg",
                   Price = 150.00m,

               },
               new Product
               {
                   ID = 2,
                   SKU = "8fw4s10",
                   Name = "Hipster",
                   Description = "Website that is designed for gen-z business owner. This site will captivate customers that favorites new trend.",
                   Image = "https://i.imgur.com/KckYFPo.jpg",
                   Price = 300.00m,

               },
                new Product
                {
                    ID = 3,
                    SKU = "4nj38s10",
                    Name = "Antique",
                    Description = "Website that gear towards older generation customer. Very comprehensive and well designed website that will increase your profit immediately.",
                    Image = "https://i.imgur.com/rIRLFbX.jpg",
                    Price = 180.00m,

                },
                new Product
                {
                    ID = 4,
                    SKU = "7mj38s10",
                    Name = "Comic",
                    Description = "Website that is for comic fan user. This design will flourish with incoming traffic of comic and action hero lovers.",
                    Image = "https://i.imgur.com/xf5nzhK.jpg",
                    Price = 210.00m,

                },
                new Product
                {
                    ID = 5,
                    SKU = "12j38s10",
                    Name = "Nature",
                    Description = "Website that is one of our best seller. This nature design is sure to bring people who wants to be away from fast paced society and enjoy what nature has to offer.",
                    Image = "https://i.imgur.com/1k8nogz.jpg",
                    Price = 2000.00m,

                },
                new Product
                {
                    ID = 6,
                    SKU = "8fg38s10",
                    Name = "Technical",
                    Description = "Website that aims to change and new things in the market. This website breathe in scalability and agile.",
                    Image = "https://i.imgur.com/q1OefoY.jpg",
                    Price = 200.00m,

                },
               new Product
               {
                   ID = 7,
                   SKU = "8fw8s10",
                   Name = "Greyscale",
                   Description = "Website that is affordable and simple to user's eyes. The format is easy to follow and navigate.",
                   Image = "https://i.imgur.com/lJrL4Sr.jpg",
                   Price = 75.00m,

               },
                new Product
                {
                    ID = 8,
                    SKU = "yv538s10",
                    Name = "Cozy",
                    Description = "Website that just looking at it brings coziness in your heart. Having this design will leave you with christmas everyday.",
                    Image = "https://i.imgur.com/ZesihIk.jpg",
                    Price = 240.00m,

                },
                new Product
                {
                    ID = 9,
                    SKU = "83nd8fn3",
                    Name = "Colorful",
                    Description = "Website that pursue on innovation and vibrant schema. This website illustrate all of the beautiful colors in the world into one. Sure to bring in heavy traffic.",
                    Image = "https://i.imgur.com/26bU5zY.png",
                    Price = 350.00m,

                },
                new Product
                {
                    ID = 10,
                    SKU = "8fj38s10",
                    Name = "Modern",
                    Description = "Website that thrives in modern society and its fast changes. This website is for end user with modern taste and elegant details.",
                    Image = "https://i.imgur.com/aHUKS0C.png",
                    Price = 200.00m,
                }
                );
        }

        /// <summary>
        /// Using the dbset of product
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<Carts> Cart { get; set; }
        public DbSet<CartItems> CartItems { get; set; }


    }
}
