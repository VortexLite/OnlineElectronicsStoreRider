using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class CartController : Controller
{
    private readonly IProfileService _profileService;
    private readonly IShoppingCartItemService _shoppingCartItemService;
    private readonly IProductService _productService;

    private IBaseResponse<int> profile;
    public CartController(IProfileService profileService, 
        IShoppingCartItemService shoppingCartItemService,
        IProductService productService)
    {
        _profileService = profileService;
        _shoppingCartItemService = shoppingCartItemService;
        _productService = productService;
    }
    public async Task<IActionResult> Index()
    {
        profile = await _profileService.GetByName(User.Identity.Name);
        var cart = await _shoppingCartItemService.GetShoppingCartBy(profile.Data);
        
        return PartialView("_CartPartialView", cart);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCart(int id)
    {
        profile = await _profileService.GetByName(User.Identity.Name);
        var product = await _shoppingCartItemService.AddProductInCart(id, profile.Data);
        var cart = await _shoppingCartItemService.GetShoppingCartBy(profile.Data);

        //return RedirectToAction("Index", "Cart");
        return PartialView("_CartPartialView", cart);
    }
}