using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Product;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IProductService
{
    Task<IBaseResponse<List<Product>>> GetProducts();
    Task<IBaseResponse<Product>> GetProduct(int id);
    Task<IBaseResponse<Product>> GetByNameProduct(string name);
    Task<IBaseResponse<bool>> DeleteProduct(int id);
    /*Task<IBaseResponse<CategoryViewModel>> CreateCategory(CategoryViewModel categoryViewModel);
    Task<IBaseResponse<Category>> EditCategory(CategoryViewModel categoryViewModel);*/
}