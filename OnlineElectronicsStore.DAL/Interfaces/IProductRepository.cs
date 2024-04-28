using Microsoft.AspNetCore.Http;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.ViewModels.Menu;
using OnlineElectronicsStore.Domain.ViewModels.Product;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product> GetByNameAsync(string name);

    Task<List<ProductViewModel>> GetProductWithImagesAsync();

    Task<List<ProductViewModel>> GetsByNameAsync(string name);

    Task<Product> GetProdutWithImageByIdAsync(int id);
    
    Task<ProductDetailViewModel> GetProductDetailAsync(int id);
    
    Task<bool> CreateProductWithImageAsync(CreateProductViewModel viewModel);
    
    Task<bool> ConvertFileAsync(List<IFormFile> entities, int idProduct);
    
    Task<bool> CreateObjectsAsync(List<Image> entities);
}