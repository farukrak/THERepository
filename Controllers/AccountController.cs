using AloeExpress.Models;
using AloeExpress.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Provider> _userManager;
        private readonly SignInManager<Provider> _signInManager;

        public AccountController(UserManager<Provider> userManager,
                              SignInManager<Provider> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var provider = new Provider
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

                var result = await _userManager.CreateAsync(provider, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(provider, false);

                    result = await _userManager.CreateAsync(provider, model.Password);


                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(provider, "user");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var provider = await _userManager.FindByEmailAsync(model.Email);

            if (provider == null)
            {
                NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email,
                    model.Password,
                    model.RememberMe,
                    false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel
            {
                Id = User.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            if (model.Id == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            Provider userEmail = await _userManager.FindByIdAsync(model.Id);

            if (ModelState.IsValid)
            {
                var provider = await _userManager.FindByIdAsync(model.Id);
                if (provider == null)
                {
                    return NotFound();
                }

                var result = await _userManager.ChangeEmailAsync(provider,
                                                                model.OldPassword,
                                                                model.NewPassword);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }
    }
}
