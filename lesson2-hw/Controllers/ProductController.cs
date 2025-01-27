using lesson2_hw.Entities;
using lesson2_hw.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson2_hw.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Product1",
                Description = "Product1",
                Pirce = 10,
                Discount = 2,
            },
            new Product
            {
                Id = 2,
                Name = "Product1",
                Description = "Product1",
                Pirce = 10,
                Discount = 2,
            },
            new Product
            {
                Id = 3,
                Name = "Product1",
                Description = "Product1",
                Pirce = 10,
                Discount = 2,
            },
        };
        public IActionResult Index()
        {
            var vm = new ProductsViewModel
            {
                Products = products
            };
            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            var item = products.FirstOrDefault(e => e.Id == id);
            if (item != null)
            {
                products.Remove(item);
                TempData["Message"] = $"{item.Name} employee deleted successfully";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product(),
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Product.Id = (new Random()).Next(1, 10000);
                products.Add(model.Product);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var product = products.FirstOrDefault(e => e.Id == id);

            if (product == null)
            {
                BadRequest();
            }

            var vm = new ProductAddViewModel
            {
                Product = product
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(ProductAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pr = products.FirstOrDefault(e => e.Id == model.Product.Id);

                if (pr != null)
                {
                    pr.Name = model.Product.Name;
                    pr.Description = model.Product.Description;
                    pr.Pirce = model.Product.Pirce;
                    pr.Discount = model.Product.Discount;

                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

    }
}
