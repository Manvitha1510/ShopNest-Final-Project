using Microsoft.AspNetCore.Mvc;
using ShopNest.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopNest.Controllers
{
    public class ProductsController : Controller
    {
        // Simulated in-memory product list
        private static List<Product> _products = new List<Product>
        {
            new Product { Name = "Bluetooth Speaker", Category = "Electronics", Price = 49.99M, Stock = 30, Description = "Portable speaker with Bluetooth 5.0 and deep bass." },
            new Product { Name = "Wireless Mouse", Category = "Electronics", Price = 29.99M, Stock = 50, Description = "Compact and ergonomic wireless mouse." }
        };

        // ------------------ CREATE ------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _products.Add(product);
                TempData["Message"] = $"Product '{product.Name}' added successfully.";
                return RedirectToAction("List");
            }

            return View(product);
        }

        // ------------------ READ (LIST) ------------------
        [HttpGet]
        public IActionResult View()
        {
            return View(_products);
        }

        // ------------------ EDIT (UPDATE) ------------------
        [HttpGet]
        public IActionResult Edit(string name)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("List");

            var product = _products.FirstOrDefault(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (product == null)
                return RedirectToAction("List");

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product updated)
        {
            var product = _products.FirstOrDefault(p => p.Name.Equals(updated.Name, System.StringComparison.OrdinalIgnoreCase));
            if (product != null && ModelState.IsValid)
            {
                product.Category = updated.Category;
                product.Price = updated.Price;
                product.Stock = updated.Stock;
                product.Description = updated.Description;

                TempData["Message"] = $"Product '{product.Name}' updated successfully.";
                return RedirectToAction("List");
            }

            return View(updated);
        }

        // ------------------ DELETE ------------------
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                var item = _products.FirstOrDefault(p => p.Name.Equals(model.Name, System.StringComparison.OrdinalIgnoreCase));
                if (item != null)
                {
                    _products.Remove(item);
                    TempData["Message"] = $"Product '{model.Name}' was deleted.";
                    return RedirectToAction("List");
                }

                ModelState.AddModelError("", $"No product found with the name '{model.Name}'.");
            }
            else
            {
                ModelState.AddModelError("Name", "Product name is required.");
            }

            return View();
        }
    }
}
