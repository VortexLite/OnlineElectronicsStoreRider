using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface INavigationService
{
    Task<IBaseResponse<List<Navigation>>> GetNavigationsAsync();
    Task<IBaseResponse<Navigation>> GetNavigationAsync(int id);
    Task<IBaseResponse<bool>> DeleteNavigationAsync(int id);
    
    //Доработка
    //Task<IBaseResponse<CategoryViewModel>> CreateCategory(CategoryViewModel categoryViewModel);
    //Task<IBaseResponse<Category>> EditCategory(CategoryViewModel categoryViewModel);
}