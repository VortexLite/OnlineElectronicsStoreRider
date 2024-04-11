using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels;
using OnlineElectronicsStore.Domain.ViewModels.Product;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IBaseResponse<List<Product>>> GetProductsAsync()
    {
        var baseResponse = new BaseResponse<List<Product>>();
        try
        {
            var product = await _productRepository.SelectAsync();
            if (product.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = product;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Product>>()
            {
                Desription = $"[GetProductsAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Product>> GetProductAsync(int id)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = product;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Product>()
            {
                Desription = $"[GetProductAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Product>> GetByNameProductAsync(string name)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.GetByNameAsync(name);
            if (product == null)
            {
                baseResponse.Desription = $"Element with name:{name} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = product;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Product>()
            {
                Desription = $"[GetByNameProductAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<List<ProductViewModel>>> GetProductWithImagesAsync()
    {
        var baseResponse = new BaseResponse<List<ProductViewModel>>();
        try
        {
            var productsWithImage = await _productRepository.GetProductWithImagesAsync();
            if (productsWithImage == null)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = productsWithImage;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<ProductViewModel>>()
            {
                Desription = $"[GetProductWithImagesAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Product>> GetProductWithImagesByIdAsync(int id)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.GetProdutWithImageByIdAsync(id);
            if (product == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = product;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Product>()
            {
                Desription = $"[GetProductWithImagesByIdAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<ProductDetailViewModel>> GetProductDetailAsync(int id)
    {
        var baseResponse = new BaseResponse<ProductDetailViewModel>();
        try
        {
            var product = await _productRepository.GetProductDetailAsync(id);
            if (product == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = product;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<ProductDetailViewModel>()
            {
                Desription = $"[GetProductDetailAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<List<ProductViewModel>>> GetsByNameAsync(string name)
    {
        var baseResponse = new BaseResponse<List<ProductViewModel>>();
        try
        {
            var productWithImage = await _productRepository.GetsByNameAsync(name);
            if (productWithImage == null)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = productWithImage;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<ProductViewModel>>()
            {
                Desription = $"[GetsByNameAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProductAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            await _productRepository.DeleteAsync(product);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteProductAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateProductAsync(ProductViewModel productViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var product = new Product()
            {
                Name = productViewModel.Name
            };

            await _productRepository.CreateAsync(product);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateProductAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Product>> EditProductAsync(ProductViewModel productViewModel)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.GetAsync(productViewModel.Id);
            if (product == null)
            {
                baseResponse.Desription = $"Element with id:{productViewModel.Id} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            product.Name = productViewModel.Name;

            await _productRepository.UpdateAsync(product);
            baseResponse.Data = product;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Product>()
            {
                Desription = $"[EditProductAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}