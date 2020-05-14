using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Http;
using ECommerceMVC.Models.Service;
using Microsoft.Extensions.Configuration;

namespace ECommerceMVC.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class ProductsController : Controller
    {
        // Local properties that are being used to access methods
        private readonly IProductManager _productManager;
        // Image file that will be attach to this properties after submit button 
        [BindProperty]
        public IFormFile Image { get; set; }

        /// <summary>
        /// blob object 
        /// </summary>
        public Blob blob { get; set; }
        /// <summary>
        /// constructor that instantiate blob object as soon as pages are render
        /// </summary>
        /// <param name="productManager">interface of product</param>
        /// <param name="configuration">using it as mock placer for blob object</param>
        public ProductsController(IProductManager productManager, IConfiguration configuration)
        {
            _productManager = productManager;
            blob = new Blob(configuration);
        }

        /// <summary>
        /// Index page 
        /// </summary>
        /// <returns>showing allof the product</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _productManager.GetAllInventories());
        }

        /// <summary>
        /// Detail of the product using the id
        /// </summary>
        /// <param name="id">id of the product</param>
        /// <returns>product that's been selected</returns>
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productManager.GetInventoryById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Getting the page to create a product
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post method to create a product from admin page
        /// </summary>
        /// <param name="product">product to be created</param>
        /// <returns>view page with product</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SKU,Name,Price,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.GetTempFileName();

                using (var memoryStream = System.IO.File.Create(filePath))
                {
                    await Image.CopyToAsync(memoryStream);
                }

                await blob.UploadFile("product", Image.FileName, filePath);

                var Blob = await blob.GetBlob(Image.FileName, "product");
                product.Image = Blob.Uri.ToString();

                await _productManager.CreateInventory(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        /// <summary>
        /// Getting specific product from db to edit and stores the url for later use in tempdata
        /// </summary>
        /// <param name="id">id of the product</param>
        /// <returns>view page with edit data</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productManager.GetInventoryById(id);
            product = await _productManager.UpdateInventories(product);
            if (product == null)
            {
                return NotFound();
            }
            TempData["ImageURL"] = product.Image;
            return View(product);
        }

        //post method that will edit the product that of ID
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SKU,Name,Price,Description")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    {
                        var filePath = Path.GetTempFileName();

                        using (var memoryStream = System.IO.File.Create(filePath))
                        {
                            await Image.CopyToAsync(memoryStream);
                        }

                        await blob.UploadFile("product", Image.FileName, filePath);

                        var Blob = await blob.GetBlob(Image.FileName, "product");
                        product.Image = Blob.Uri.ToString();
                    }
                    else
                    {
                        product.Image = TempData["ImageURL"] as string;
                    }

                    Product newProduct = await _productManager.UpdateInventories(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _productManager.GetInventoryById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        /// <summary>
        /// Getting the product to be deleted
        /// </summary>
        /// <param name="id">id of the product</param>
        /// <returns>product detail and asking user if they are sure</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productManager.GetInventoryById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// post method that actually deletes the product
        /// </summary>
        /// <param name="id">id of the product</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productManager.GetInventoryById(id);

            await _productManager.DeleteInventories(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
