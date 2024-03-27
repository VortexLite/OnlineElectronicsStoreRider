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
    
    public async Task<IBaseResponse<List<Product>>> GetProducts()
    {
        var baseResponse = new BaseResponse<List<Product>>();
        try
        {
            var product = await _productRepository.Select();
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
                Desription = $"[GetProducts] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Product>> GetProduct(int id)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.Get(id);
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
                Desription = $"[GetProduct] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Product>> GetByNameProduct(string name)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.GetByName(name);
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
                Desription = $"[GetByNameProduct] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<List<ProductViewModel>>> GetProductWithImages()
    {
        var baseResponse = new BaseResponse<List<ProductViewModel>>();
        try
        {
            var productsWithImage = await _productRepository.GetProductWithImages();
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
                Desription = $"[GetProductWithImages] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Product>> GetProductWithImagesById(int id)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.GetProdutWithImageById(id);
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
                Desription = $"[GetProductWithImagesById] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<List<ProductViewModel>>> GetsByName(string name)
    {
        var baseResponse = new BaseResponse<List<ProductViewModel>>();
        try
        {
            var productWithImage = await _productRepository.GetsByName(name);
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
                Desription = $"[GetsByName] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProduct(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var product = await _productRepository.Get(id);
            if (product == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            await _productRepository.Delete(product);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteProduct] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateProduct(ProductViewModel productViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var product = new Product()
            {
                Name = productViewModel.Name
            };

            await _productRepository.Create(product);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateProduct] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Product>> EditProduct(ProductViewModel productViewModel)
    {
        var baseResponse = new BaseResponse<Product>();
        try
        {
            var product = await _productRepository.Get(productViewModel.Id);
            if (product == null)
            {
                baseResponse.Desription = $"Element with id:{productViewModel.Id} not found";
                baseResponse.StatusCode = StatusCode.ProductElementNotFound;
                return baseResponse;
            }

            product.Name = productViewModel.Name;

            await _productRepository.Update(product);
            baseResponse.Data = product;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Product>()
            {
                Desription = $"[EditProduct] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}