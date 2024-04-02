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
    public OrderService(IOrderRepository orderRepository, IProfileRepository profileRepository,
        IOrderDetailService orderDetailService)
    {
        _orderRepository = orderRepository;
        _profileRepository = profileRepository;
        _orderDetailService = orderDetailService;
    }
    public async Task<IBaseResponse<List<Order>>> GetOrders()
    {
        var baseResponse = new BaseResponse<List<Order>>();
        try
        {
            var orders = await _orderRepository.Select();
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
                Desription = $"[GetOrders] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Order>> GetOrder(int id)
    {
        var baseResponse = new BaseResponse<Order>();
        try
        {
            var order = await _orderRepository.Get(id);
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
                Desription = $"[GetOrder] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteOrder(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var order = await _orderRepository.Get(id);
            if (order == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.OrderElementNotFound;
                return baseResponse;
            }

            await _orderRepository.Delete(order);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteOrder] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateOrder(OrderViewModel orderViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var profile = await _profileRepository.Get(orderViewModel.IdProfile);
            
            var order = new Order()
            {
                DateOrder = DateTime.Now,
                TotalCost = orderViewModel.TotalCost,
                Address = profile.Address,
                IdProfile = orderViewModel.IdProfile,
                IdDeliveryType = orderViewModel.IdDeliveryType,
                IdStatusDelivery = 1
            };

            await _orderRepository.Create(order);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            await _orderDetailService.CreateOrderDetail(order.Id, orderViewModel);

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}