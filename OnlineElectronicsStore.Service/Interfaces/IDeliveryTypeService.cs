using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IDeliveryTypeService
{
    Task<IBaseResponse<List<DeliveryType>>> GetDeliveryTypes();
    Task<IBaseResponse<DeliveryType>> GetDeliveryType(int id);
    Task<IBaseResponse<bool>> DeleteDeliveryType(int id);
}