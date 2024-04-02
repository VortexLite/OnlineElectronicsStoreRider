using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.OrderViewModel;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IOrderService
{
    Task<IBaseResponse<List<Order>>> GetOrders();
    Task<IBaseResponse<Order>> GetOrder(int id);
    Task<IBaseResponse<bool>> DeleteOrder(int id);
    Task<IBaseResponse<bool>> CreateOrder(OrderViewModel orderViewModel);
}