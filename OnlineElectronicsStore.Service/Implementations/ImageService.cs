using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    
    public async Task<IBaseResponse<List<Image>>> GetImages()
    {
        var baseResponse = new BaseResponse<List<Image>>();
        try
        {
            var images = await _imageRepository.Select();
            if (images.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ImageElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = images;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Image>>()
            {
                Desription = $"[GetImages] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Image>> GetImage(int id)
    {
        var baseResponse = new BaseResponse<Image>();
        try
        {
            var images = await _imageRepository.Get(id);
            if (images == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ImageElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = images;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Image>()
            {
                Desription = $"[GetImage] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteImage(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var images = await _imageRepository.Get(id);
            if (images == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ImageElementNotFound;
                return baseResponse;
            }

            await _imageRepository.Delete(images);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteImage] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateImage(Image image)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var category = new Image()
            {
                IdProduct = image.IdProduct,
                ImageData = image.ImageData
            };

            await _imageRepository.Create(category);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateImage] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}