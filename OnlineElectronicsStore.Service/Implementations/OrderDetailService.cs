using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.OrderViewModel;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public OrderDetailService(IOrderDetailsRepository orderDetailsRepository,
        IShoppingCartItemRepository shoppingCartItemRepository)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _shoppingCartItemRepository = shoppingCartItemRepository;
    }
    public async Task<IBaseResponse<List<OrderDetail>>> GetOrderDetails()
    {
        var baseResponse = new BaseResponse<List<OrderDetail>>();
        try
        {
            var orderDetails = await _orderDetailsRepository.Select();
            if (orderDetails.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.OrderDetailElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = orderDetails;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<OrderDetail>>()
            {
                Desription = $"[GetOrderDetails] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<OrderDetail>> GetOrderDetail(int id)
    {
        var baseResponse = new BaseResponse<OrderDetail>();
        try
        {
            var orderDetail = await _orderDetailsRepository.Get(id);
            if (orderDetail == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.OrderDetailElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = orderDetail;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<OrderDetail>()
            {
                Desription = $"[GetOrderDetail] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteOrderDetail(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var orderDetail = await _orderDetailsRepository.Get(id);
            if (orderDetail == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.OrderDetailElementNotFound;
                return baseResponse;
            }

            await _orderDetailsRepository.Delete(orderDetail);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteOrderDetail] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateOrderDetail(int idOrder, OrderViewModel orderViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var cart = await _shoppingCartItemRepository.GetShoppingCartBy(orderViewModel.IdProfile);
            
            foreach (var item in cart)
            {
                var orderDetail = new OrderDetail()
                {
                    IdOrder = idOrder,
                    IdProduct = item.IdProduct,
                    Quantity = item.Quantity,
                    Price = item.Price * item.Quantity
                };
                await _orderDetailsRepository.Create(orderDetail);
            }
            
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateOrderDetail] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}