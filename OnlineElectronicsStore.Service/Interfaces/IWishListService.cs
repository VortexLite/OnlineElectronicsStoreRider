using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IWishListService
{
    Task<IBaseResponse<List<WishList>>> GetWishListsAsync();
    Task<IBaseResponse<WishList>> GetWishListAsync(int id);
    Task<IBaseResponse<bool>> DeleteWishListAsync(int id);
}