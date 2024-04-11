using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Helpers;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Cart;
using OnlineElectronicsStore.Domain.ViewModels.Menu;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class MenuController : Controller
{
    private readonly IProfileService _profileService;
    private readonly IShoppingCartItemService _shoppingCartItemService;
    private readonly IOrderService _orderService;

    private IBaseResponse<int> _idProfile;
    public MenuController(IProfileService profileService, 
        IShoppingCartItemService shoppingCartItemService, 
        IOrderService orderService)
    {
        _profileService = profileService;
        _shoppingCartItemService = shoppingCartItemService;
        _orderService = orderService;
    }
    public async Task<IActionResult> Cart()
    {
        _idProfile = await _profileService.GetByNameAsync(User.Identity.Name);
        var cart = await _shoppingCartItemService.GetShoppingCartByAsync(_idProfile.Data);
        var profile = await _profileService.GetProfileAsync(_idProfile.Data);

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
        var cartProduct = await _shoppingCartItemService.DeleteShoppingCartItemAsync(id);
        if (cartProduct.Data == true)
        {
            return RedirectToAction("Cart");
        }

        return RedirectToAction("Index", "Home");
    }
    
    public async Task<IActionResult> AddQuantityProduct(int IdCart, int currentValue)
    {
        var cart = await _shoppingCartItemService.EditCartAsync(currentValue + 1, IdCart);
        
        return RedirectToAction("Cart", "Menu");
    }
    
    public async Task<IActionResult> DelQuantityProduct(int IdCart, int currentValue)
    {
        var cart = await _shoppingCartItemService.EditCartAsync(currentValue - 1, IdCart);
        
        return RedirectToAction("Cart", "Menu");
    }

    public async Task<IActionResult> Order()
    {
        _idProfile = await _profileService.GetByNameAsync(User.Identity.Name);
        var orders = await _orderService.GetOrderViewModelsAsync(_idProfile.Data);
        var profile = await _profileService.GetProfileAsync(_idProfile.Data);

        if (profile.StatusCode == Domain.Enum.StatusCode.OK)
        {
            var response = new Pair<IBaseResponse<List<OrderViewModel>>, IBaseResponse<Profile>>()
            {
                First = orders,
                Second = profile
            };
            return View(response);
        }

        return RedirectToAction("Index", "Home");
    }
}