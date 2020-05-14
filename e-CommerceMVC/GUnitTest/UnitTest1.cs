using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using ECommerceMVC.Models.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GUnitTest
{
    public class UnitTest1
    {
        private readonly Mock<IProductManager> _moqManager;

        public UnitTest1()
        {
            _moqManager = new Mock<IProductManager>();
        }
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
        public async void AbleToCreateAProductInOurDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("AbleToCreateAProductInOurDatabase")
                 .Options;
            
            // using the context of database
            using(StoreDbContext storeDb = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(storeDb);

                Product product = new Product()
                {
                    Name = "Bob Ross",
                    Description = "Happy little accident"
                };
                await ps.CreateInventory(product);

                var data = storeDb.Products.Find(product.ID);

                Assert.Equal(product, data);
            }
        }

        [Fact]
        public async void AbleToReadAProductFromDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("AbleToReadAProductFromDatabase")
                .Options;

            // using the context of database
            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(storeDb);

                Product product = new Product()
                {
                    Name = "Bob Ross",
                    Description = "Happy little accident"
                };

                await ps.CreateInventory(product);

                var data = storeDb.Products.Find(1);

                Assert.Equal(product, data);
            }
        }

        [Fact]
        public async void AbleToReadAllFromDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("AbleToReadAllFromDatabase")
                .Options;

            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(storeDb);

                Product product = new Product()
                {
                    Name = "Bob Ross",
                    Description = "Happy little accident"
                };

                Product product1 = new Product()
                {
                    Name = "PeaPod",
                    Description = "Pocket Squarel"
                };

                List<Product> ProductList = new List<Product>();

                ProductList.Add(product);
                ProductList.Add(product1);


                await ps.CreateInventory(product);
                await ps.CreateInventory(product1);


                var data = await storeDb.Products.ToListAsync();

                Assert.Equal(ProductList, data);
            }
        }

        [Fact]
        public async void UpdateProductToDatabase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("UpdateProductToDatabase")
                .Options;

            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(storeDb);

                Product product = new Product()
                {
                    Name = "Bob Ross",
                    Description = "Happy little accident"
                };

                await ps.CreateInventory(product);

                product.Name = "Pea Pod";

                await ps.UpdateInventories(product);

                var data = storeDb.Products.Find(product.ID);

                Assert.Equal(product.Name, data.Name);
            }
        }

        [Fact]
        public async void DeleteProductFromDataBase()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("DeleteProductFromDataBase")
                .Options;

            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                ProductService ps = new ProductService(storeDb);

                Product product = new Product()
                {
                    Name = "Bob Ross",
                    Description = "Happy little accident"
                };

                await ps.CreateInventory(product);

                await ps.DeleteInventories(product);

                var data = storeDb.Products.Find(product.ID);

                Assert.Null(data);
            }
        }
        [Fact]
        public async void CreateCart()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("CreateCart")
                .Options;

            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                CartService ps = new CartService(storeDb, _moqManager.Object);

                Carts carts = new Carts()
                {
                    Email = "bobR@gmail.com"
                    
                };

                var Cart = await ps.CreateCart(carts);

                Assert.Equal(carts.Email, Cart.Email);
            }
        }
        [Fact]
        public async void GetUserById()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("GetUserById")
                .Options;

            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                CartService ps = new CartService(storeDb, _moqManager.Object);

                Carts carts = new Carts()
                {
                    Email = "bobR@gmail.com"

                };

                await ps.CreateCart(carts);
                var result = await ps.GetCartById(carts.Email);

                Assert.Equal(carts, result);
            }
        }
     
        [Fact]
        public async void AbleToGetCartItems()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("AbleToGetCartItems")
                .Options;

            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                CartItemsService cis = new CartItemsService(storeDb);
                
                CartItems ci = new CartItems()
                {
                    ProductID = 1,
                    CartsID = 1,
                    Quantity = 200
                };

                await cis.CreateCartItems(ci);

                var result = await cis.GetCartItemsById(ci.ID);

                Assert.Equal(200, result.Quantity);
            }
        }
        [Fact]
        public async void AbleToCreateCartItem()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("AbleToCreateCartItem")
                .Options;

            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                CartItemsService cis = new CartItemsService(storeDb);

                CartItems ci = new CartItems()
                {
                    ProductID = 1,
                    CartsID = 1,
                    Quantity = 200
                };

                var result = await cis.CreateCartItems(ci);

                Assert.Equal(1, result.ID);
            }
        }
        [Fact]
        public async void AbleToDeleteCartItem()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("AbleToDeleteCartItem")
                .Options;

            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                CartItemsService cis = new CartItemsService(storeDb);

                CartItems ci = new CartItems()
                {
                    ProductID = 1,
                    CartsID = 1,
                    Quantity = 200
                };

                await cis.CreateCartItems(ci);
                await cis.DeleteCartItems(ci.ID);
                var result = await cis.GetCartItemsById(ci.ID);

                Assert.Null(result);
            }
        }
        [Fact]
        public async void AbleToUpdateQuantity()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>()
               .UseInMemoryDatabase("AbleToUpdateQuantity")
                .Options;

            using (StoreDbContext storeDb = new StoreDbContext(options))
            {
                CartItemsService cis = new CartItemsService(storeDb);

                CartItems ci = new CartItems()
                {
                    ProductID = 1,
                    CartsID = 1,
                    Quantity = 420
                };

                await cis.CreateCartItems(ci);
                ci.Quantity = 69;
                await cis.UpdateCartItems(ci);
                var blazeIt = await cis.GetCartItemsById(ci.ID);

                Assert.Equal(69, blazeIt.Quantity);
            }
        }

    }
}
