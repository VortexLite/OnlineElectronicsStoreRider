using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class WishListService : IWishListService
{
    private readonly IWishListRepository _wishListRepository;

    public WishListService(IWishListRepository wishListRepository)
    {
        _wishListRepository = wishListRepository;
    }
    public async Task<IBaseResponse<List<WishList>>> GetWishLists()
    {
        var baseResponse = new BaseResponse<List<WishList>>();
        try
        {
            var wishLists = await _wishListRepository.Select();
            if (wishLists.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.WishListElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = wishLists;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<WishList>>()
            {
                Desription = $"[GetWishLists] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<WishList>> GetWishList(int id)
    {
        var baseResponse = new BaseResponse<WishList>();
        try
        {
            var wishList = await _wishListRepository.Get(id);
            if (wishList == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.WishListElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = wishList;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<WishList>()
            {
                Desription = $"[GetWishList] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteWishList(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var wishList = await _wishListRepository.Get(id);
            if (wishList == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.WishListElementNotFound;
                return baseResponse;
            }

            await _wishListRepository.Delete(wishList);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteWishList] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}