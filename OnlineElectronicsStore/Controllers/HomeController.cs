using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.Helpers;
using OnlineElectronicsStore.Models;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly INavigationService _navigationService;
    private readonly IProductService _productService;
    
    public HomeController(ILogger<HomeController> logger, INavigationService navigationService, IProductService productService)
    {
        _logger = logger;
        _navigationService = navigationService;
        _productService = productService;
    }
    
    public async Task<IActionResult> Index()
    {
        var response = await _navigationService.NavigationRowsById(1);
        var response2 = await _productService.GetProducts();
        var tempResponse = new Pair<IBaseResponse<List<string>>, IBaseResponse<List<Product>>>()
        {
            First = response,
            Second = response2
        };
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(tempResponse);
        }

        return RedirectToAction("Error");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetNavigationByCategoryId(int id)
    {
        var response = await _navigationService.NavigationRowsById(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data.ToList());
        }

        return RedirectToAction("Error");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}