using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.OrderViewModel;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IOrderDetailService
{
    Task<IBaseResponse<List<OrderDetail>>> GetOrderDetailsAsync();
    Task<IBaseResponse<OrderDetail>> GetOrderDetailAsync(int id);
    Task<IBaseResponse<bool>> DeleteOrderDetailAsync(int id);
    Task<IBaseResponse<bool>> CreateOrderDetailAsync(int idOrder, OrderViewModel orderViewModel);
}