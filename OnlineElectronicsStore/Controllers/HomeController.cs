using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.Helpers;
using OnlineElectronicsStore.Domain.ViewModels.Product;
using OnlineElectronicsStore.Models;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProducerService _producerService;
    private readonly IProductService _productService;
    private readonly IImageService _imageService;
    
    public HomeController(ILogger<HomeController> logger, IProducerService producerService, IProductService productService, IImageService imageService)
    {
        _logger = logger;
        _producerService = producerService;
        _productService = productService;
        _imageService = imageService;
    }
    
    public async Task<IActionResult> Index()
    {
        /*var response = await _producerService.NavigationRowsById(1);
        var response2 = await _productService.GetProducts();
        var response3 = await _imageService.GetImages();
        var tempresponse2 = new Pair<IBaseResponse<List<Product>>, IBaseResponse<List<Image>>>()
        {
            First = response2,
            Second = response3
        };
        
        var tempResponse = new Pair<IBaseResponse<List<Producer>>, Pair<IBaseResponse<List<Product>>, IBaseResponse<List<Image>>>>()
        {
            First = response,
            Second = tempresponse2
        };*/
        
        
        var responseNavigation = await _producerService.NavigationRowsById(14);
        var responseProductWithImage = await _productService.GetProductWithImages();
        
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