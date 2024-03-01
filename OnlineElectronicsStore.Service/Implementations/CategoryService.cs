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
    public async Task<IBaseResponse<IEnumerable<Category>>> GetCategories()
    {
        var baseResponse = new BaseResponse<IEnumerable<Category>>();
        try
        {
            var category = await _categoryRepository.Select();
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
            return new BaseResponse<IEnumerable<Category>>()
            {
                Desription = $"[GetCategories] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Category>> GetCategory(int id)
    {
        var baseResponse = new BaseResponse<Category>();
        try
        {
            var category = await _categoryRepository.Get(id);
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
                Desription = $"[GetCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<Category>> GetByNameCategory(string name)
    {
        var baseResponse = new BaseResponse<Category>();
        try
        {
            var category = await _categoryRepository.GetByName(name);
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
                Desription = $"[GetByNameCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteCategory(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var category = await _categoryRepository.Get(id);
            if (category == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.CategoryElementsNotFound;
                return baseResponse;
            }

            await _categoryRepository.Delete(category);
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponse<CategoryViewModel>> CreateCategory(CategoryViewModel categoryViewModel)
    {
        var baseResponse = new BaseResponse<CategoryViewModel>();
        try
        {
            var category = new Category()
            {
                Name = categoryViewModel.Name
            };

            await _categoryRepository.Create(category);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<CategoryViewModel>()
            {
                Desription = $"[CreateCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public Task<IBaseResponse<Category>> EditCategory(int id, CategoryViewModel categoryViewModel)
    {
        throw new NotImplementedException();
    }

    public async Task<IBaseResponse<Category>> EditCategory(CategoryViewModel categoryViewModel)
    {
        var baseResponse = new BaseResponse<Category>();
        try
        {
            var category = await _categoryRepository.Get(categoryViewModel.Id);
            if (category == null)
            {
                baseResponse.Desription = $"Element with id:{categoryViewModel.Id} not found";
                baseResponse.StatusCode = StatusCode.CategoryElementsNotFound;
                return baseResponse;
            }

            category.Name = categoryViewModel.Name;

            await _categoryRepository.Update(category);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Category>()
            {
                Desription = $"[CreateCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}