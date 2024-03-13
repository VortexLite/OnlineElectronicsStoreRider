using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
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
}