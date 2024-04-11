using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class ProducerService : IProducerService
{
    private readonly IProducerRepository _producerRepository;

    public ProducerService(IProducerRepository producerRepository)
    {
        _producerRepository = producerRepository;
    }
    
    public async Task<IBaseResponse<List<Producer>>> GetProducersAsync()
    {
        var baseResponse = new BaseResponse<List<Producer>>();
        try
        {
            var producers = await _producerRepository.SelectAsync();
            if (producers.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ProducerElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = producers;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Producer>>()
            {
                Desription = $"[GetProducersAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Producer>> GetProducerAsync(int id)
    {
        var baseResponse = new BaseResponse<Producer>();
        try
        {
            var producers = await _producerRepository.GetAsync(id);
            if (producers == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProducerElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = producers;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Producer>()
            {
                Desription = $"[GetProducerAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    public async Task<IBaseResponse<List<Producer>>> NavigationByRowsAsync(string name)
    {
        var baseResponse = new BaseResponse<List<Producer>>();
        try
        {
            var producer = await _producerRepository.NavigationByRowsAsync(name);
            if (producer == null)
            {
                baseResponse.Desription = $"Element with name:{name} not found";
                baseResponse.StatusCode = StatusCode.ProducerElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = producer;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Producer>>()
            {
                Desription = $"[NavigationByRowsAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<List<Producer>>> NavigationRowsByIdAsync(int id)
    {
        var baseResponse = new BaseResponse<List<Producer>>();
        try
        {
            var producer = await _producerRepository.NavigationRowsByIdAsync(id);
            if (producer == null)
            {
                baseResponse.Desription = $"Element with name:{id} not found";
                baseResponse.StatusCode = StatusCode.ProducerElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = producer;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Producer>>()
            {
                Desription = $"[NavigationRowsByIdAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProducerAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var producer = await _producerRepository.GetAsync(id);
            if (producer == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            await _producerRepository.DeleteAsync(producer);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteProducerAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}