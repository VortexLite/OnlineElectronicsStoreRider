using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class NavigationService : INavigationService
{
    private readonly INavigationRepository _navigationRepository;

    public NavigationService(INavigationRepository navigationRepository)
    {
        _navigationRepository = navigationRepository;
    }
    public async Task<IBaseResponse<List<Navigation>>> GetNavigationsAsync()
    {
        var baseResponse = new BaseResponse<List<Navigation>>();
        try
        {
            var navigation = await _navigationRepository.SelectAsync();
            if (navigation.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.NavigationElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = navigation;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Navigation>>()
            {
                Desription = $"[GetNavigationsAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Navigation>> GetNavigationAsync(int id)
    {
        var baseResponse = new BaseResponse<Navigation>();
        try
        {
            var navigation = await _navigationRepository.GetAsync(id);
            if (navigation == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.NavigationElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = navigation;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Navigation>()
            {
                Desription = $"[GetNavigationAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteNavigationAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var navigation = await _navigationRepository.GetAsync(id);
            if (navigation == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.NavigationElementNotFound;
                return baseResponse;
            }

            await _navigationRepository.DeleteAsync(navigation);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteNavigationAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}