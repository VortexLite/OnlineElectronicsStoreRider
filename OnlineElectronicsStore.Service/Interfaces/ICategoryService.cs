using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Category;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface ICategoryService
{
    Task<IBaseResponse<List<Category>>> GetCategoriesAsync();
    Task<IBaseResponse<Category>> GetCategoryAsync(int id);
    Task<IBaseResponse<Category>> GetByNameCategoryAsync(string name);
    Task<IBaseResponse<bool>> DeleteCategoryAsync(int id);
    Task<IBaseResponse<bool>> CreateCategoryAsync(CategoryViewModel categoryViewModel);
    Task<IBaseResponse<Category>> EditCategoryAsync(CategoryViewModel categoryViewModel);
}