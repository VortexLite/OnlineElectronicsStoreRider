using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Models;

namespace OnlineElectronicsStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly INavigationRepository _navigationRepository;
    
    public HomeController(ILogger<HomeController> logger, INavigationRepository navigationService)
    {
        _logger = logger;
        _navigationRepository = navigationService;
    }
    
    public async Task<IActionResult> Index()
    {
        var nav = await _navigationRepository.NavigationRowsById(1);
        
        return View(nav);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetNavigationByCategoryId(int id)
    {
        var nav = await _navigationRepository.NavigationRowsById(id);
        
        return Json(nav);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}