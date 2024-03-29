using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Cart;
using OnlineElectronicsStore.Domain.ViewModels.Category;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IShoppingCartItemService
{
    Task<IBaseResponse<List<ShoppingCartItem>>> GetShoppingCartItems();
    Task<IBaseResponse<ShoppingCartItem>> GetShoppingCartItem(int id);
    Task<IBaseResponse<List<CartViewModel>>> GetShoppingCartBy(int idProfile);
    Task<IBaseResponse<bool>> DeleteShoppingCartItem(int id);
    Task<IBaseResponse<bool>> AddProductInCart(int idProduct, int idProfile);
    /*Task<IBaseResponse<bool>> CreateCategory(CategoryViewModel categoryViewModel);
    Task<IBaseResponse<Category>> EditCategory(CategoryViewModel categoryViewModel);*/
}