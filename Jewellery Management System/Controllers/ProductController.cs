using Jewellery_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Controllers
{
    public class ProductController:Controller
    {
        private readonly IProductRepository _prod;
        public ProductController(IProductRepository productRepository) {
            _prod = productRepository;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.OwnerName = HttpContext.Session.GetString("OwnerName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                Product newProduct = _prod.Add(product);
                return RedirectToAction("Products");
            }
            return View();
        }
        public IActionResult Products()
        {
            return View(_prod.GetProducts());
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var product = _prod.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _prod.Edit(product);
            return RedirectToAction("Products");
        }
        public IActionResult Details(int id)
        {
            return View(_prod.GetProduct(id));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_prod.GetProduct(id));
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _prod.Delete((int)id);
            return RedirectToAction("Products");
        }
    }
}
