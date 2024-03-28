using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IProductCharacteristicService
{
    Task<IBaseResponse<List<ProductCharacteristic>>> GetProductCharacteristics();
    Task<IBaseResponse<ProductCharacteristic>> GetProductCharacteristic(int id);
    Task<IBaseResponse<bool>> DeleteProductCharacteristic(int id);
}