using AloeExpress.Models;
using AloeExpress.Services;
using AloeExpress.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Created = DateTime.Now,
                    RecipientFullName = model.RecipientFullName,
                    IsDeleted = false
                };
                _orderService.Create(order);
            }
            return View();
        }
        [HttpPost]
        public IActionResult GetOrders(int Id)
        {
            var orders = _orderService.GetOrders(Id);
            var ordrs = new List<Order>();
            foreach(var item in orders)
            {
                ordrs.Add(new Order()
                {
                    Id = item.Id,
                    Product = item.Product,
                    ProductType = item.ProductType,
                    Created = item.Created,
                    IsDeleted = item.IsDeleted
                });
            }
            return View(ordrs);
        }
    }
}
