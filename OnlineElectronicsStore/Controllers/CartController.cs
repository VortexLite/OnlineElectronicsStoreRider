using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class CartController : Controller
{
    private readonly IProfileService _profileService;
    private readonly IShoppingCartItemService _shoppingCartItemService;

    private IBaseResponse<int> profile;
    public CartController(IProfileService profileService, 
        IShoppingCartItemService shoppingCartItemService)
    {
        _profileService = profileService;
        _shoppingCartItemService = shoppingCartItemService;
    }
    public async Task<IActionResult> Index()
    {
        profile = await _profileService.GetByNameAsync(User.Identity.Name);
        var cart = await _shoppingCartItemService.GetShoppingCartByAsync(profile.Data);
        
        return PartialView("_CartPartialView", cart);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCart(int id)
    {
        profile = await _profileService.GetByNameAsync(User.Identity.Name);
        var product = await _shoppingCartItemService.AddProductInCartAsync(id, profile.Data);
        var cart = await _shoppingCartItemService.GetShoppingCartByAsync(profile.Data);
        
        /*var product = await _shoppingCartItemService.AddProductInCart(id, 1);
        var cart = await _shoppingCartItemService.GetShoppingCartBy(1);*/

        //return RedirectToAction("Index", "Cart");
        return PartialView("_CartPartialView", cart);
    }
}