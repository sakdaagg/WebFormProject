using Microsoft.AspNetCore.Mvc;
using WebFormProject.Models;
using WebFormProject.Services.Abstract;
using WebFromProject.Entities.Entities;

namespace WebFormProject.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.AuthenticateAsync(model.Username, model.Password);
            if (user != null)
            {
                // Başarılı giriş
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            }
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AspNetUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                NormalizedUserName = model.Username.ToUpper(),
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };

            await _userService.RegisterUserAsync(user, model.Password);
            return RedirectToAction("Login");
        }
        return View(model);
    }
}
