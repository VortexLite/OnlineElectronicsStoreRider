using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface INavigationService
{
    Task<IBaseResponse<IEnumerable<Navigation>>> GetNavigations();
    Task<IBaseResponse<Navigation>> GetNavigation(int id);
    Task<IBaseResponse<List<string>>> NavigationByRows(string name);
    Task<IBaseResponse<List<string>>> NavigationRowsById(int id);
    Task<IBaseResponse<bool>> DeleteNavigation(int id);
    
    //Доработка
    //Task<IBaseResponse<CategoryViewModel>> CreateCategory(CategoryViewModel categoryViewModel);
    //Task<IBaseResponse<Category>> EditCategory(CategoryViewModel categoryViewModel);
}