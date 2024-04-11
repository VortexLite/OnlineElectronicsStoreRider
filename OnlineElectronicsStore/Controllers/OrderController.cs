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

    private IBaseResponse<int> _idProfile = null;
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
        if (_idProfile == null)
        {
            _idProfile = await _profileService.GetByNameAsync(User.Identity.Name);
        }
        
        var profile = await _profileService.GetProfileAsync(_idProfile.Data);
        var cart = await _shoppingCartItemService.GetShoppingCartByAsync(_idProfile.Data);
        var deliveryType = await _deliveryTypeService.GetDeliveryTypesAsync();

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
        if (_idProfile == null)
        {
            _idProfile = await _profileService.GetByNameAsync(User.Identity.Name);
        }
        
        var cart = await _shoppingCartItemService.GetShoppingCartByAsync(_idProfile.Data);
        var profile = await _profileService.GetProfileAsync(_idProfile.Data);

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
    public async Task<IActionResult> SaveContact(ContactViewModel contactViewModel)
    {
        if (_idProfile == null)
        {
            _idProfile = await _profileService.GetByNameAsync(User.Identity.Name);
        }
        
        var editprofile = await _profileService.EditProfileByContactAsync(contactViewModel, _idProfile.Data);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderViewModel orderViewModel)
    {
        if (_idProfile == null)
        {
            _idProfile = await _profileService.GetByNameAsync(User.Identity.Name);
        }

        var createOrder = await _orderService.CreateOrderAsync(orderViewModel);
        var deleteCart = await _shoppingCartItemService.DeleteShoppingCartItemsAsync(_idProfile.Data);

        if (createOrder.StatusCode == Domain.Enum.StatusCode.OK &&
            deleteCart.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("Index", "Home");
        }
        
        //Доробить
        return RedirectToAction("Index", "Home");
    }
}