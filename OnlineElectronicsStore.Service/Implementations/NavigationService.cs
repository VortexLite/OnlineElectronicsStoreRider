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
    public async Task<IBaseResponse<List<Navigation>>> GetNavigations()
    {
        var baseResponse = new BaseResponse<List<Navigation>>();
        try
        {
            var navigation = await _navigationRepository.Select();
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
                Desription = $"[GetNavigations] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Navigation>> GetNavigation(int id)
    {
        var baseResponse = new BaseResponse<Navigation>();
        try
        {
            var navigation = await _navigationRepository.Get(id);
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
                Desription = $"[GetNavigation] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteNavigation(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var navigation = await _navigationRepository.Get(id);
            if (navigation == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.NavigationElementNotFound;
                return baseResponse;
            }

            await _navigationRepository.Delete(navigation);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteNavigation] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}