using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.OrderViewModel;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IOrderDetailService _orderDetailService;
    private readonly IShoppingCartItemService _shoppingCartItemService;
    
    public OrderService(IOrderRepository orderRepository, IProfileRepository profileRepository,
        IOrderDetailService orderDetailService, IShoppingCartItemService shoppingCartItemService)
    {
        _orderRepository = orderRepository;
        _profileRepository = profileRepository;
        _orderDetailService = orderDetailService;
        _shoppingCartItemService = shoppingCartItemService;
    }
    public async Task<IBaseResponse<List<Order>>> GetOrdersAsync()
    {
        var baseResponse = new BaseResponse<List<Order>>();
        try
        {
            var orders = await _orderRepository.SelectAsync();
            if (orders.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.OrderElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = orders;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Order>>()
            {
                Desription = $"[GetOrdersAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<List<Domain.ViewModels.Menu.OrderViewModel>>> GetOrderViewModelsAsync(int idProfile)
    {
        var baseResponse = new BaseResponse<List<Domain.ViewModels.Menu.OrderViewModel>>();
        try
        {
            var profile = await _profileRepository.GetAsync(idProfile);
            var orders = await _orderRepository.GetOrdersWithDeliveryStatusOrderDetailAsync(idProfile);
            if (orders.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.OrderElementNotFound;
                return baseResponse;
            }

            var orderViewModels = new List<Domain.ViewModels.Menu.OrderViewModel>();

            foreach (var order in orders)
            {
                var item = new Domain.ViewModels.Menu.OrderViewModel()
                {
                    Id = order.Id,
                    DateOrder = order.DateOrder.ToString("dd-MM-yy"),
                    Quantity = order.OrderDetails.Sum(i => i.Quantity),
                    TotalCost = order.OrderDetails.Sum(i => i.Quantity * i.Price),
                    NameStatus = order.StatusDelivery.Name,
                    NameDelivery = order.DeliveryType.Name,
                    NameAccount = profile.Name
                };
                orderViewModels.Add(item);
            }
            
            baseResponse.Data = orderViewModels;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Domain.ViewModels.Menu.OrderViewModel>>()
            {
                Desription = $"[GetOrderViewModelsAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Order>> GetOrderAsync(int id)
    {
        var baseResponse = new BaseResponse<Order>();
        try
        {
            var order = await _orderRepository.GetAsync(id);
            if (order == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.OrderElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = order;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Order>()
            {
                Desription = $"[GetOrderAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteOrderAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var order = await _orderRepository.GetAsync(id);
            if (order == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.OrderElementNotFound;
                return baseResponse;
            }

            await _orderRepository.DeleteAsync(order);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteOrderAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateOrderAsync(OrderViewModel orderViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var profile = await _profileRepository.GetAsync(orderViewModel.IdProfile);
            
            var order = new Order()
            {
                DateOrder = DateTime.Now,
                TotalCost = orderViewModel.TotalCost,
                Address = profile.Address,
                IdProfile = orderViewModel.IdProfile,
                IdDeliveryType = orderViewModel.IdDeliveryType,
                IdStatusDelivery = 1
            };

            await _orderRepository.CreateAsync(order);
            await _orderDetailService.CreateOrderDetailAsync(order.Id, orderViewModel);

            await _shoppingCartItemService.DeleteShoppingCartItemsAsync(profile.Id);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateCategoryAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}