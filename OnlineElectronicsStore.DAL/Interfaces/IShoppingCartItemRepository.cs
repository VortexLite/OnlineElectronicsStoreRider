using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IShoppingCartItemRepository : IBaseRepository<ShoppingCartItem>
{
    Task<List<ShoppingCartItem>> GetShoppingCartBy(int idProfile);
    Task<ShoppingCartItem> GetCartProduct(int id);
    Task<bool> AddProductInCart(int idProduct, int idProfile);
}