using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Cart;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class ShoppingCartItemService : IShoppingCartItemService
{
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public ShoppingCartItemService(IShoppingCartItemRepository shoppingCartItemRepository)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
    }
    public async Task<IBaseResponse<List<ShoppingCartItem>>> GetShoppingCartItems()
    {
        var baseResponse = new BaseResponse<List<ShoppingCartItem>>();
        try
        {
            var shoppingCartItems = await _shoppingCartItemRepository.Select();
            if (shoppingCartItems.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ShoppingCartItemElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = shoppingCartItems;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<ShoppingCartItem>>()
            {
                Desription = $"[GetShoppingCartItems] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<ShoppingCartItem>> GetShoppingCartItem(int id)
    {
        var baseResponse = new BaseResponse<ShoppingCartItem>();
        try
        {
            var shoppingCartItem = await _shoppingCartItemRepository.Get(id);
            if (shoppingCartItem == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ShoppingCartItemElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = shoppingCartItem;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<ShoppingCartItem>()
            {
                Desription = $"[GetShoppingCartItem] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<List<CartViewModel>>> GetShoppingCartBy(int idProfile)
    {
        var baseResponse = new BaseResponse<List<CartViewModel>>();
        try
        {
            var shoppingCartItems = await _shoppingCartItemRepository.GetShoppingCartBy(idProfile);
            if (shoppingCartItems == null)
            {
                baseResponse.Desription = $"Element with idProfile:{idProfile} not found";
                baseResponse.StatusCode = StatusCode.ShoppingCartItemElementNotFound;
                return baseResponse;
            }

            var cartViewModels = new List<CartViewModel>();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                int idImage = shoppingCartItem.Product.Id;
                var cartItem = new CartViewModel()
                {
                    Name = shoppingCartItem.Product.Name,
                    Price = shoppingCartItem.Product.Price,
                    Quantity = shoppingCartItem.Quantity,
                    ImageData = shoppingCartItem.Product.Images
                        .FirstOrDefault(i => i.IdProduct == idImage)
                        ?.ImageData
                };
                cartViewModels.Add(cartItem);
            }

            baseResponse.Data = cartViewModels;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<CartViewModel>>()
            {
                Desription = $"[GetShoppingCartBy] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteShoppingCartItem(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var shoppingCartItem = await _shoppingCartItemRepository.Get(id);
            if (shoppingCartItem == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ShoppingCartItemElementNotFound;
                return baseResponse;
            }

            await _shoppingCartItemRepository.Delete(shoppingCartItem);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteShoppingCartItem] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> AddProductInCart(int idProduct, int idProfile)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var shoppingCartItem = await _shoppingCartItemRepository.AddProductInCart(idProduct, idProfile);
            if (shoppingCartItem == null)
            {
                baseResponse.Desription = $"Element with id:{idProduct} not found";
                baseResponse.StatusCode = StatusCode.ShoppingCartItemElementNotFound;
                return baseResponse;
            }
            
            baseResponse.Data = shoppingCartItem;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[AddProductInCart] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}