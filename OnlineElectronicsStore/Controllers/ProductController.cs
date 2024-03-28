using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<IActionResult> ProductDetails(int id)
    {
        var product = await _productService.GetProductDetail(id);
        if (product == null)
        {
            return NotFound();
        }
        
        return View(product.Data);
    }
}