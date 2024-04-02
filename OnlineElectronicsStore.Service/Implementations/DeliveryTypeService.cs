using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class DeliveryTypeService : IDeliveryTypeService
{
    private readonly IDeliveryTypeRepository _deliveryTypeRepository;

    public DeliveryTypeService(IDeliveryTypeRepository deliveryTypeRepository)
    {
        _deliveryTypeRepository = deliveryTypeRepository;
    }
    public async Task<IBaseResponse<List<DeliveryType>>> GetDeliveryTypes()
    {
        var baseResponse = new BaseResponse<List<DeliveryType>>();
        try
        {
            var deliveryTypes = await _deliveryTypeRepository.Select();
            if (deliveryTypes.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.DeliveryTypeElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = deliveryTypes;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<DeliveryType>>()
            {
                Desription = $"[GetDeliveryTypes] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<DeliveryType>> GetDeliveryType(int id)
    {
        var baseResponse = new BaseResponse<DeliveryType>();
        try
        {
            var deliveryType = await _deliveryTypeRepository.Get(id);
            if (deliveryType == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.DeliveryTypeElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = deliveryType;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<DeliveryType>()
            {
                Desription = $"[GetDeliveryType] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteDeliveryType(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var deliveryType = await _deliveryTypeRepository.Get(id);
            if (deliveryType == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.DeliveryTypeElementNotFound;
                return baseResponse;
            }

            await _deliveryTypeRepository.Delete(deliveryType);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteDeliveryType] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}