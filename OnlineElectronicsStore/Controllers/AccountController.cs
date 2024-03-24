using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.ViewModels.Account;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class AccountController : Controller
{
    private readonly IAuthenticateService _authenticateService;
    private readonly IUserService _userService;

    public AccountController(IAuthenticateService authenticateService, IUserService userService)
    {
        _authenticateService = authenticateService;
        _userService = userService;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _authenticateService.AuthenticateLoginPasswordUser(loginViewModel.Login, loginViewModel.Password);
            if (user.Data != null)
            {
                await Authenticate(loginViewModel.Login);
 
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Некоректні логін і пароль");
        }

        return View(loginViewModel);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _authenticateService.AuthenticateLoginUser(registerViewModel.Login);
            if (user.Data == null)
            {
                var checkUser = await _userService.CreateUser(registerViewModel);
                if (checkUser.Data)
                {
                    await Authenticate(registerViewModel.Login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content("Error reg model");
                }
            }
            else
                ModelState.AddModelError("", "Некоректні логін і пароль");
        }

        return View(registerViewModel);
    }

    private async Task Authenticate(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, username)
        };
        
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }
}
