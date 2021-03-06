using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using ECommerceMVC.Models.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ECommerceMVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor to use user secret for our connection string
        /// </summary>
        public Startup()
        {
            var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        /// <summary>
        /// This will hold our middleware
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //adding razor page toour middle ware
            services.AddRazorPages();

            // To incorporate our dbcontext that is in the Data folder
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
            }
            );

            //to create store database fro DbContext
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
            );


            /// TO add identity to our application
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            /// Identity password configuration that will be used to implement stricter rule in password
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            /// Adding the amdin only authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin));
            });

            ///transient method that will be invoked for every instance when the interface is called
            services.AddTransient<IProductManager, ProductService>();
            services.AddTransient<ICartManager, CartService>();
            services.AddTransient<ICartItemsManager, CartItemsService>();
            services.AddTransient<IOrderManager, OrderService>();
            //Sendgrid
            services.AddTransient<IEmailSender, EmailSender>();
            //Authorization .net
            services.AddTransient<IPayment, PaymentService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            // using the static file location wwwroot
            app.UseStaticFiles();
            // adding an identity
            app.UseAuthentication();
            app.UseAuthorization();
            
            /// Seeding the roles if its in the database
            RoleInitializer.SeedData(serviceProvider);

            // Endpoint to our default home/index/id?
            app.UseEndpoints(endpoints =>
            {
                // Implementing razor page to the application endpoint
                endpoints.MapRazorPages();
                // default route
                endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
