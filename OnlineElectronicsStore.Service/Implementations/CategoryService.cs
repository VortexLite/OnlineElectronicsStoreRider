using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Category;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<IBaseResponse<List<Category>>> GetCategoriesAsync()
    {
        var baseResponse = new BaseResponse<List<Category>>();
        try
        {
            var category = await _categoryRepository.SelectAsync();
            if (category.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.CategoryElementsNotFound;
                return baseResponse;
            }

            baseResponse.Data = category;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Category>>()
            {
                Desription = $"[GetCategoriesAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Category>> GetCategoryAsync(int id)
    {
        var baseResponse = new BaseResponse<Category>();
        try
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.CategoryElementsNotFound;
                return baseResponse;
            }

            baseResponse.Data = category;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Category>()
            {
                Desription = $"[GetCategoryAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<Category>> GetByNameCategoryAsync(string name)
    {
        var baseResponse = new BaseResponse<Category>();
        try
        {
            var category = await _categoryRepository.GetByNameAsync(name);
            if (category == null)
            {
                baseResponse.Desription = $"Element with name:{name} not found";
                baseResponse.StatusCode = StatusCode.CategoryElementsNotFound;
                return baseResponse;
            }

            baseResponse.Data = category;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Category>()
            {
                Desription = $"[GetByNameCategoryAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteCategoryAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.CategoryElementsNotFound;
                return baseResponse;
            }

            await _categoryRepository.DeleteAsync(category);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteCategoryAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<bool>> CreateCategoryAsync(CategoryViewModel categoryViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var category = new Category()
            {
                Name = categoryViewModel.Name
            };

            await _categoryRepository.CreateAsync(category);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateCategoryAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Category>> EditCategoryAsync(CategoryViewModel categoryViewModel)
    {
        var baseResponse = new BaseResponse<Category>();
        try
        {
            var category = await _categoryRepository.GetAsync(categoryViewModel.Id);
            if (category == null)
            {
                baseResponse.Desription = $"Element with id:{categoryViewModel.Id} not found";
                baseResponse.StatusCode = StatusCode.CategoryElementsNotFound;
                return baseResponse;
            }

            category.Name = categoryViewModel.Name;

            await _categoryRepository.UpdateAsync(category);
            baseResponse.Data = category;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Category>()
            {
                Desription = $"[EditCategoryAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}