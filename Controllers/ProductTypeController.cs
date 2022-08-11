using AloeExpress.Models;
using AloeExpress.Services;
using AloeExpress.ViewModels.ProductType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductTypeViewModel productType)
        {
            if (!ModelState.IsValid)
            {
                return View(productType);
            }
            var prodType = new ProductType()
            {
                Name = productType.Name,
                TariffContainer = productType.TariffContainer,
                TariffAvia = productType.TariffAvia
            };

            _productTypeService.Create(prodType);

            return RedirectToAction("GetAllProductType");
        }
        [HttpGet]
        public IActionResult Edit(string name)
        {
            var prodType = _productTypeService.GetProductType(name);

            ProductTypeViewModel productTypeViewModel = new()
            {
                Name = prodType.Name,
                TariffAvia = prodType.TariffAvia,
                TariffContainer = prodType.TariffContainer
            };

            return View(productTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductTypeViewModel productType)
        {
            var prod = _productTypeService.GetProductType(productType.Name);

            ProductType prodEdit = new()
            { 
                Name = prod.Name,
                TariffContainer = prod.TariffContainer,
                TariffAvia = prod.TariffAvia
            };

            _productTypeService.Edit(prodEdit);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetAllProductType()
        {
            var prodTypes = _productTypeService.GetAllProductType();
            var prodType = new List<ProductTypeViewModel>();

            foreach(var item in prodTypes)
            {
                prodType.Add(new ProductTypeViewModel()
                {
                    Name = item.Name,
                    TariffContainer = item.TariffContainer,
                    TariffAvia = item.TariffAvia
                });
            }
            return PartialView(prodType);
        }
    }
}
