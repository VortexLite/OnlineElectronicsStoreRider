using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IDeliveryTypeService
{
    Task<IBaseResponse<List<DeliveryType>>> GetDeliveryTypesAsync();
    Task<IBaseResponse<DeliveryType>> GetDeliveryTypeAsync(int id);
    Task<IBaseResponse<bool>> DeleteDeliveryTypeAsync(int id);
}