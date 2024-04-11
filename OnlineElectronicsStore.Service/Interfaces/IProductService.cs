using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels;
using OnlineElectronicsStore.Domain.ViewModels.Product;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IProductService
{
    Task<IBaseResponse<List<Product>>> GetProductsAsync();
    Task<IBaseResponse<Product>> GetProductAsync(int id);
    Task<IBaseResponse<Product>> GetByNameProductAsync(string name);
    Task<IBaseResponse<List<ProductViewModel>>> GetProductWithImagesAsync();
    Task<IBaseResponse<Product>> GetProductWithImagesByIdAsync(int id);
    Task<IBaseResponse<ProductDetailViewModel>> GetProductDetailAsync(int id);
    Task<IBaseResponse<List<ProductViewModel>>> GetsByNameAsync(string name);
    Task<IBaseResponse<bool>> DeleteProductAsync(int id);
    Task<IBaseResponse<bool>> CreateProductAsync(ProductViewModel productViewModel);
    Task<IBaseResponse<Product>> EditProductAsync(ProductViewModel productViewModel);
}