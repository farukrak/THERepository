using AloeExpress.Models;
using AloeExpress.Services;
using AloeExpress.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            Product prd = new()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Volume = product.Quantity,
                Weight = product.Weight
            };
            _productService.Create(prd);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var product = _productService.GetProduct(Id); 
            if(product == null)
            {
                return NotFound();
            }
            ProductViewModel productView = new()
            {
                Id = Id,
                Name = product.Name,
                Weight = product.Weight,
                Volume = product.Volume,
                Quantity = product.Quantity
            };

            return View(productView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productView)
        {
            var prod = _productService.GetProduct(productView.Id);
            if(prod == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(prod);
            }
            prod.Name = productView.Name;
            prod.Quantity = productView.Quantity;
            prod.Volume = productView.Volume;
            prod.Weight = productView.Weight;

            _productService.Edit(prod);

            return RedirectToAction("Index", "Home");
        }
    }
}
