using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<List<Order>> GetOrdersWithDeliveryStatusOrderDetailAsync(int idProfile);
}