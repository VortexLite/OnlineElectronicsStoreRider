using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Cart;
using OnlineElectronicsStore.Domain.ViewModels.Category;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IShoppingCartItemService
{
    Task<IBaseResponse<List<ShoppingCartItem>>> GetShoppingCartItemsAsync();
    Task<IBaseResponse<ShoppingCartItem>> GetShoppingCartItemAsync(int id);
    Task<IBaseResponse<List<CartViewModel>>> GetShoppingCartByAsync(int idProfile);
    Task<IBaseResponse<bool>> DeleteShoppingCartItemAsync(int id);
    Task<IBaseResponse<bool>> DeleteShoppingCartItemsAsync(int id);
    Task<IBaseResponse<bool>> AddProductInCartAsync(int idProduct, int idProfile);
    Task<IBaseResponse<bool>> EditCartAsync(int currentValue, int IdCart);
    /*Task<IBaseResponse<bool>> CreateCategory(CategoryViewModel categoryViewModel);*/
}