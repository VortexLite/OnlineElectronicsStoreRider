using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface INavigationService
{
    Task<IBaseResponse<List<Navigation>>> GetNavigations();
    Task<IBaseResponse<Navigation>> GetNavigation(int id);
    Task<IBaseResponse<bool>> DeleteNavigation(int id);
    
    //Доработка
    //Task<IBaseResponse<CategoryViewModel>> CreateCategory(CategoryViewModel categoryViewModel);
    //Task<IBaseResponse<Category>> EditCategory(CategoryViewModel categoryViewModel);
}