using Microsoft.AspNetCore.Mvc;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Helpers;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Cart;
using OnlineElectronicsStore.Domain.ViewModels.OrderViewModel;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Controllers;

public class OrderController : Controller
{
    private readonly IProfileService _profileService;
    private readonly IShoppingCartItemService _shoppingCartItemService;
    private readonly IDeliveryTypeService _deliveryTypeService;
    private readonly IOrderService _orderService;

    private IBaseResponse<int> IdProfile;
    public OrderController(IProfileService profileService, 
        IShoppingCartItemService shoppingCartItemService,
        IDeliveryTypeService deliveryTypeService,
        IOrderService orderService)
    {
        _profileService = profileService;
        _shoppingCartItemService = shoppingCartItemService;
        _deliveryTypeService = deliveryTypeService;
        _orderService = orderService;
    }
    public async Task<IActionResult> Index()
    {
        IdProfile = await _profileService.GetByName(User.Identity.Name);
        var profile = await _profileService.GetProfile(IdProfile.Data);
        var cart = await _shoppingCartItemService.GetShoppingCartBy(IdProfile.Data);
        var deliveryType = await _deliveryTypeService.GetDeliveryTypes();

        var response = new Triple<IBaseResponse<Profile>, IBaseResponse<List<CartViewModel>>, IBaseResponse<List<DeliveryType>>>()
        {
            First = profile,
            Second = cart,
            Third = deliveryType
        };
        
        return View(response);
    }
    
    public async Task<IActionResult> Contact()
    {
        IdProfile = await _profileService.GetByName(User.Identity.Name);
        var cart = await _shoppingCartItemService.GetShoppingCartBy(IdProfile.Data);
        var profile = await _profileService.GetProfile(IdProfile.Data);

        if (cart.StatusCode == Domain.Enum.StatusCode.OK &&
            profile.StatusCode == Domain.Enum.StatusCode.OK )
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

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderViewModel orderViewModel)
    {
        var createOrder = await _orderService.CreateOrder(orderViewModel);
        
        return RedirectToAction("Index", "Home");
    }
}