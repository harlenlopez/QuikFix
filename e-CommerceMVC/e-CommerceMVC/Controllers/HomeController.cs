﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManager _product;

        public HomeController(IProductManager product)
        {
            _product = product;
        }
        /// <summary>
        /// Rendering index page
        /// </summary>
        /// <returns>returning to our index page</returns>
        public async Task<IActionResult> Index()
        {
            var result = await _product.GetAllInventories();
            return View(result);
        }
    }
}