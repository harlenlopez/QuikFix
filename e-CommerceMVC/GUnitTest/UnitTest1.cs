using ECommerceMVC.Data;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace GUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddProductName()
        {
            Product product = new Product()
            {
                Name = "Bob"
            };

            Assert.Equal("Bob", product.Name);
        }

        [Fact]
        public void CanAddSKU()
        {
            Product product = new Product()
            {
                SKU = "abcdefG12"
            };

            Assert.Equal("abcdefG12", product.SKU);
        }

        [Fact]
        public void CanAddPrice()
        {
            Product product = new Product()
            {
                Price = 200.00m
            };

            Assert.Equal(200.00m, product.Price);
        }

        [Fact]
        public void CanAddDescription()
        {
            Product product = new Product()
            {
                Description = "Happy Little Trees"
            };

            Assert.Equal("Happy Little Trees", product.Description);

        }

        [Fact]
        public void CanAddImagePropery()
        {
            Product product = new Product()
            {
                Image = "http://google.com"
            };

            Assert.Equal("http://google.com", product.Image);
        }

        [Fact]
        public void AbleToCreateAProductInOurDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("AbleToCreateAProductInOurDatabase")
                 .Options;
            
            using(StoreDbContext storeDb = new StoreDbContext(options))
            {

            }
        }
    }
}
