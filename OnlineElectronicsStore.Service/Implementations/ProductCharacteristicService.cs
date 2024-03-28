using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class ProductCharacteristicService : IProductCharacteristicService
{
    private readonly IProductCharacteristicRepository _productCharacteristicRepository;

    public ProductCharacteristicService(IProductCharacteristicRepository productCharacteristicRepository)
    {
        _productCharacteristicRepository = _productCharacteristicRepository;
    }
    public async Task<IBaseResponse<List<ProductCharacteristic>>> GetProductCharacteristics()
    {
        var baseResponse = new BaseResponse<List<ProductCharacteristic>>();
        try
        {
            var productCharacteristics = await _productCharacteristicRepository.Select();
            if (productCharacteristics.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ProductCharacteristicElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = productCharacteristics;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<ProductCharacteristic>>()
            {
                Desription = $"[GetProductCharacteristics] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<ProductCharacteristic>> GetProductCharacteristic(int id)
    {
        var baseResponse = new BaseResponse<ProductCharacteristic>();
        try
        {
            var productCharacteristic = await _productCharacteristicRepository.Get(id);
            if (productCharacteristic == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProductCharacteristicElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = productCharacteristic;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<ProductCharacteristic>()
            {
                Desription = $"[GetProductCharacteristic] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProductCharacteristic(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var productCharacteristic = await _productCharacteristicRepository.Get(id);
            if (productCharacteristic == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProductCharacteristicElementNotFound;
                return baseResponse;
            }

            await _productCharacteristicRepository.Delete(productCharacteristic);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteProductCharacteristic] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}