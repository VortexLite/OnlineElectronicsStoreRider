using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Helpers;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Cart;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class MenuController : Controller
{
    private readonly IProfileService _profileService;
    private readonly IShoppingCartItemService _shoppingCartItemService;

    private IBaseResponse<int> IdProfile;
    public MenuController(IProfileService profileService, 
        IShoppingCartItemService shoppingCartItemService)
    {
        _profileService = profileService;
        _shoppingCartItemService = shoppingCartItemService;
    }
    public async Task<IActionResult> Cart()
    {
        IdProfile = await _profileService.GetByName(User.Identity.Name);
        var cart = await _shoppingCartItemService.GetShoppingCartBy(IdProfile.Data);
        var profile = await _profileService.GetProfile(IdProfile.Data);

        if (cart.StatusCode == Domain.Enum.StatusCode.OK &&
            profile.StatusCode == Domain.Enum.StatusCode.OK)
        {
            var response = new Pair<IBaseResponse<List<CartViewModel>>, IBaseResponse<Profile>>()
            {
                First = cart,
                Second = profile
            };
            return View(response);
        }

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> DeleteCartProduct(int id)
    {
        var cartProduct = await _shoppingCartItemService.DeleteShoppingCartItem(id);
        if (cartProduct.Data == true)
        {
            return RedirectToAction("Cart");
        }

        return RedirectToAction("Index", "Home");
    }
    
    public async Task<IActionResult> AddQuantityProduct(int IdCart, int currentValue)
    {
        var cart = await _shoppingCartItemService.EditCart(currentValue + 1, IdCart);
        
        return RedirectToAction("Cart", "Menu");
    }
    
    public async Task<IActionResult> DelQuantityProduct(int IdCart, int currentValue)
    {
        var cart = await _shoppingCartItemService.EditCart(currentValue - 1, IdCart);
        
        return RedirectToAction("Cart", "Menu");
    }
}