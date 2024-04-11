using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.OrderViewModel;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IOrderService
{
    Task<IBaseResponse<List<Order>>> GetOrdersAsync();
    Task<IBaseResponse<List<Domain.ViewModels.Menu.OrderViewModel>>> GetOrderViewModelsAsync(int idProfile);
    Task<IBaseResponse<Order>> GetOrderAsync(int id);
    Task<IBaseResponse<bool>> DeleteOrderAsync(int id);
    Task<IBaseResponse<bool>> CreateOrderAsync(OrderViewModel orderViewModel);
}