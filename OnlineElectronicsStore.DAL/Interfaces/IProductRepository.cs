using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.ViewModels.Product;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product> GetByNameAsync(string name);

    Task<List<ProductViewModel>> GetProductWithImagesAsync();

    Task<List<ProductViewModel>> GetsByNameAsync(string name);

    Task<Product> GetProdutWithImageByIdAsync(int id);
    
    Task<ProductDetailViewModel> GetProductDetailAsync(int id);
}