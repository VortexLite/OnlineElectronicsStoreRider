using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IProductCharacteristicService
{
    Task<IBaseResponse<List<ProductCharacteristic>>> GetProductCharacteristicsAsync();
    Task<IBaseResponse<ProductCharacteristic>> GetProductCharacteristicAsync(int id);
    Task<IBaseResponse<bool>> DeleteProductCharacteristicAsync(int id);
}