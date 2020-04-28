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
            modelBuilder.Entity<Carts>().HasData(
               new Carts
               {
                   ID = 1,
                   Email = "jinwoov@gmail.com"
               },
               new Carts
               {
                   ID = 2,
                   Email = "bobR@gmail.com"
               }

               );

            modelBuilder.Entity<CartItems>().HasData(
               new CartItems
               {
                   ID = 1,
                   CartsID = 1,
                   ProductID = 1,
                   Quantity = 2,
               },
               new CartItems
               {
                   ID = 2,
                   CartsID = 2,
                   ProductID = 5,
                   Quantity = 20,
               }

               );

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   ID = 1,
                   SKU = "12jrj830",
                   Name = "Classic",
                   Description = "A no nonsense design tailored to businesses with decerning taste. The Classic theme will allow your business to focus on what is important and not waste time with unnecessary features.",
                   Image = "https://i.imgur.com/ex7bvr4.jpg",
                   Price = 1500.00m,

               },
               new Product
               {
                   ID = 2,
                   SKU = "8fw4s10",
                   Name = "Hipster",
                   Description = "Not your average design, be unique, be bold and carve your own path. The flexibility in this design will ensure no two are the same,so go ahead,and let your creativity show.",
                   Image = "https://i.imgur.com/KckYFPo.jpg",
                   Price = 3000.00m,

               },
                new Product
                {
                    ID = 3,
                    SKU = "4nj38s10",
                    Name = "Antique",
                    Description = "A classic design that is reminiscent of a by gone era. With a comprehensive and eloquently designed website, you will see an increase in positive user experiences, resulting in a better profit margin.",
                    Image = "https://i.imgur.com/rIRLFbX.jpg",
                    Price = 1800.00m,

                },
                new Product
                {
                    ID = 4,
                    SKU = "7mj38s10",
                    Name = "Comic",
                    Description = "An exciting design for the hero in everyone. The comic design will allow the inner hero of your business to shine.Do not be fooled be the straightforward design, this layout packs a punch!",
                    Image = "https://i.imgur.com/xf5nzhK.jpg",
                    Price = 2100.00m,

                },
                new Product
                {
                    ID = 5,
                    SKU = "12j38s10",
                    Name = "Nature",
                    Description = "Get away from the hustle and bustle and take a deep breath. With a design that will make even the most adventurous feel right at home, this design is for those who are not afraid to get dirty and enjoy the great outdoors.",
                    Image = "https://i.imgur.com/1k8nogz.jpg",
                    Price = 2000.00m,

                },
                new Product
                {
                    ID = 6,
                    SKU = "8fg38s10",
                    Name = "Technical",
                    Description = "A design focused on showcasing technical data to convey your designs and all you to keep productive. With its straight forward layout you can spend less time fixing your site and more time being creative and doing what your passionate about.",
                    Image = "https://i.imgur.com/q1OefoY.jpg",
                    Price = 2000.00m,

                },
               new Product
               {
                   ID = 7,
                   SKU = "8fw8s10",
                   Name = "Greyscale",
                   Description = "An elegant and minimalistic design to punctuate the things that are most important.This designs beauty is in its simplicity, when you need to present your site in a straightforward way this is the design to use.",
                   Image = "https://i.imgur.com/lJrL4Sr.jpg",
                   Price = 1750.00m,

               },
                new Product
                {
                    ID = 8,
                    SKU = "yv538s10",
                    Name = "Cozy",
                    Description = "Like a warm fire, your favorite sweater or a home cooked meal, this design will make you feel right at home.So settle in and get cozy, this design will make you want to take it easy and spend some time to enjoy the simple things.",
                    Image = "https://i.imgur.com/ZesihIk.jpg",
                    Price = 1400.00m,

                },
                new Product
                {
                    ID = 9,
                    SKU = "83nd8fn3",
                    Name = "Colorful",
                    Description = "with a well thought out design you are ensured to have a site that pops. Not afraid of a little color, go crazy with your palette and show the world how far a little color can go.",
                    Image = "https://i.imgur.com/26bU5zY.png",
                    Price = 1900.00m,

                },
                new Product
                {
                    ID = 10,
                    SKU = "8fj38s10",
                    Name = "Modern",
                    Description = "Website that thrives in modern society and its fast changes. This website is for end user with modern taste and elegant details.",
                    Image = "https://i.imgur.com/aHUKS0C.png",
                    Price = 2000.00m,
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
