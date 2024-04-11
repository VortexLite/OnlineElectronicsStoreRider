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
    public async Task<IBaseResponse<List<ShoppingCartItem>>> GetShoppingCartItemsAsync()
    {
        var baseResponse = new BaseResponse<List<ShoppingCartItem>>();
        try
        {
            var shoppingCartItems = await _shoppingCartItemRepository.SelectAsync();
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
                Desription = $"[GetShoppingCartItemsAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<ShoppingCartItem>> GetShoppingCartItemAsync(int id)
    {
        var baseResponse = new BaseResponse<ShoppingCartItem>();
        try
        {
            var shoppingCartItem = await _shoppingCartItemRepository.GetAsync(id);
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
                Desription = $"[GetShoppingCartItemAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<List<CartViewModel>>> GetShoppingCartByAsync(int idProfile)
    {
        var baseResponse = new BaseResponse<List<CartViewModel>>();
        try
        {
            var shoppingCartItems = await _shoppingCartItemRepository.GetShoppingCartByAsync(idProfile);
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
                    Id = shoppingCartItem.Id,
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
                Desription = $"[GetShoppingCartByAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteShoppingCartItemAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var shoppingCartItem = await _shoppingCartItemRepository.GetAsync(id);
            if (shoppingCartItem == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ShoppingCartItemElementNotFound;
                return baseResponse;
            }

            await _shoppingCartItemRepository.DeleteAsync(shoppingCartItem);
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

    public async Task<IBaseResponse<bool>> DeleteShoppingCartItemsAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var shoppingCartItem = await _shoppingCartItemRepository.GetShoppingCartByAsync(id);
            if (shoppingCartItem == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ShoppingCartItemElementNotFound;
                return baseResponse;
            }

            await _shoppingCartItemRepository.DeleteColectionsAsync(shoppingCartItem);
            
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteShoppingCartItemsAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> AddProductInCartAsync(int idProduct, int idProfile)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var shoppingCartItem = await _shoppingCartItemRepository.AddProductInCartAsync(idProduct, idProfile);
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
                Desription = $"[AddProductInCartAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> EditCartAsync(int updateValue, int IdCart)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var cart = await _shoppingCartItemRepository.GetCartProductAsync(IdCart);
            if (cart == null)
            {
                baseResponse.Desription = $"Element with id:{IdCart} not found";
                baseResponse.StatusCode = StatusCode.ShoppingCartItemElementNotFound;
                
                return baseResponse;
            }
            
            if (cart.Product.Amount >= updateValue)
            {
                cart.Quantity = updateValue;
                await _shoppingCartItemRepository.UpdateAsync(cart);
                
                baseResponse.Data = true;
                baseResponse.StatusCode = StatusCode.OK;
            }
            else
            {
                baseResponse.Data = false;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[EditCartAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}