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
    
    public async Task<IBaseResponse<List<Producer>>> GetProducers()
    {
        var baseResponse = new BaseResponse<List<Producer>>();
        try
        {
            var producers = await _producerRepository.Select();
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
                Desription = $"[GetProducers] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Producer>> GetProducer(int id)
    {
        var baseResponse = new BaseResponse<Producer>();
        try
        {
            var producers = await _producerRepository.Get(id);
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
                Desription = $"[GetProducer] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    public async Task<IBaseResponse<List<Producer>>> NavigationByRows(string name)
    {
        var baseResponse = new BaseResponse<List<Producer>>();
        try
        {
            var producer = await _producerRepository.NavigationByRows(name);
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
                Desription = $"[NavigationByRows] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<List<Producer>>> NavigationRowsById(int id)
    {
        var baseResponse = new BaseResponse<List<Producer>>();
        try
        {
            var producer = await _producerRepository.NavigationRowsById(id);
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
                Desription = $"[NavigationRowsById] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProducer(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var producer = await _producerRepository.Get(id);
            if (producer == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            await _producerRepository.Delete(producer);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteProducer] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}