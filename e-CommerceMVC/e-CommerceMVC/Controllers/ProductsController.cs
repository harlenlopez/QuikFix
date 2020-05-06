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
        private readonly IProductManager _productManager;
        [BindProperty]
        public IFormFile Image { get; set; }
        public Blob blob { get; set; }
        public ProductsController(IProductManager productManager, IConfiguration configuration)
        {
            _productManager = productManager;
            blob = new Blob(configuration);
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _productManager.GetAllInventories());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productManager.GetInventoryById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SKU,Name,Price,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                //var filePath = Path.GetTempPath() + Image.FileName;
                //var cloudContainer = blob.GetContainer("product");

                //using (var memoryStream = new MemoryStream())
                //{
                //    await Image.CopyToAsync(memoryStream);

                //}
                await blob.UploadFile("product", Image.FileName, Image);

                var Blob = await blob.GetBlob(Image.FileName, "product");
                product.Image = Blob.Uri.ToString();

                await _productManager.CreateInventory(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productManager.GetInventoryById(id);
            product = await _productManager.UpdateInventories(product);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                        await blob.UploadFile("product", Image.FileName, Image);

                        var Blob = await blob.GetBlob(Image.FileName, "product");
                        product.Image = Blob.Uri.ToString();
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

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productManager.GetInventoryById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
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
