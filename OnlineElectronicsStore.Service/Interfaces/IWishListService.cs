using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IWishListService
{
    Task<IBaseResponse<List<WishList>>> GetWishLists();
    Task<IBaseResponse<WishList>> GetWishList(int id);
    Task<IBaseResponse<bool>> DeleteWishList(int id);
}