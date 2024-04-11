using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IShoppingCartItemRepository : IBaseRepository<ShoppingCartItem>
{
    Task<List<ShoppingCartItem>> GetShoppingCartByAsync(int idProfile);
    Task<ShoppingCartItem> GetCartProductAsync(int id);
    Task<bool> AddProductInCartAsync(int idProduct, int idProfile);
    Task<bool> DeleteColectionsAsync(List<ShoppingCartItem> entity);
}