using AloeExpress.Data;
using AloeExpress.Models;
using AloeExpress.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Controllers
{
    public class RecipientController : Controller
    {
        private readonly IRecipientService _recipientService;
        public RecipientController(IRecipientService recipientService)
        {
            _recipientService = recipientService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Recipient recipient)
        {
            if (!ModelState.IsValid)
            {
                return View(recipient);
            }
            Recipient rec = new()
            {
                FullName = recipient.FullName,
                Orders = recipient.Orders,
                SecurityCode = recipient.SecurityCode,
                IsDeleted = false
            };

            _recipientService.Create(rec);
            return RedirectToAction();
        }
        [HttpGet]
        public IActionResult FindMe()
        {
            return View();
        }
    }
}
