using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Category;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface ICategoryService
{
    Task<IBaseResponse<List<Category>>> GetCategories();
    Task<IBaseResponse<Category>> GetCategory(int id);
    Task<IBaseResponse<Category>> GetByNameCategory(string name);
    Task<IBaseResponse<bool>> DeleteCategory(int id);
    Task<IBaseResponse<bool>> CreateCategory(CategoryViewModel categoryViewModel);
    Task<IBaseResponse<Category>> EditCategory(CategoryViewModel categoryViewModel);
}