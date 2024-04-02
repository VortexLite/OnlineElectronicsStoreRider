using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.OrderViewModel;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IOrderDetailService
{
    Task<IBaseResponse<List<OrderDetail>>> GetOrderDetails();
    Task<IBaseResponse<OrderDetail>> GetOrderDetail(int id);
    Task<IBaseResponse<bool>> DeleteOrderDetail(int id);
    Task<IBaseResponse<bool>> CreateOrderDetail(int idOrder, OrderViewModel orderViewModel);
}