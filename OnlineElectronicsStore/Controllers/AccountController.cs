using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.Entity;
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
            var user = await _authenticateService.AuthenticateLoginPasswordUserAsync(loginViewModel.Login, loginViewModel.Password);
            if (user.Data != null)
            {
                await Authenticate(user.Data);
 
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
            var userAuth = await _authenticateService.AuthenticateLoginUserAsync(registerViewModel.Login);
            if (userAuth.Data == null)
            {
                var checkUser = await _userService.CreateUserAsync(registerViewModel);
                if (checkUser.Data)
                {
                    var user = await _userService.GetByLoginAsync(registerViewModel.Login);
                    await Authenticate(user.Data);
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

    private async Task Authenticate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
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
