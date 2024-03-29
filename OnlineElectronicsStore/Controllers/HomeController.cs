using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.Helpers;
using OnlineElectronicsStore.Domain.ViewModels.Product;
using OnlineElectronicsStore.Models;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

//[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProducerService _producerService;
    private readonly IProductService _productService;
    private readonly IShoppingCartItemService _shoppingCartItemService;
    private readonly IProfileService _profileService;
    
    private IBaseResponse<int> profile;
    
    public HomeController(ILogger<HomeController> logger, IProducerService producerService, 
        IProductService productService,
        IShoppingCartItemService shoppingCartItemService,
        IProfileService profileService)
    {
        _logger = logger;
        _producerService = producerService;
        _productService = productService;
        _shoppingCartItemService = shoppingCartItemService;
        _profileService = profileService;
    }
    public async Task<IActionResult> Index()
    { 
        var responseNavigation = await _producerService.NavigationRowsById(1);
        var responseProductWithImage = await _productService.GetProductWithImages();
        profile = await _profileService.GetByName(User.Identity.Name);
        var responseCart = await _shoppingCartItemService.GetShoppingCartBy(profile.Data);
        
        var responseResult = new Pair<IBaseResponse<List<Producer>>, IBaseResponse<List<ProductViewModel>>>()
        {
            First = responseNavigation,
            Second = responseProductWithImage
        };
        
        if (responseNavigation.StatusCode == Domain.Enum.StatusCode.OK &&
            responseProductWithImage.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(responseResult);
        }

        return RedirectToAction("Error");
    }
    
    public async Task<IActionResult> Search(string search)
    {
        if (string.IsNullOrEmpty(search))
        {
            return RedirectToAction("Index");
        }

        var responseNavigation = await _producerService.NavigationRowsById(1);
        var searchResults = await _productService.GetsByName(search);

        var responseResult = new Pair<IBaseResponse<List<Producer>>, IBaseResponse<List<ProductViewModel>>>()
        {
            First = responseNavigation,
            Second = searchResults
        };

        return View("Index", responseResult);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetNavigationByCategoryId(int id)
    {
        var response = await _producerService.NavigationRowsById(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Json(response.Data);
        }

        return RedirectToAction("Error");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}