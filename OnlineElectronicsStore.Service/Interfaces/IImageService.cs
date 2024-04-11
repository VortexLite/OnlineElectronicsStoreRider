using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;


namespace OnlineElectronicsStore.Service.Interfaces;

public interface IImageService
{
    Task<IBaseResponse<List<Image>>> GetImagesAsync();
    Task<IBaseResponse<Image>> GetImageAsync(int id);
    Task<IBaseResponse<bool>> DeleteImageAsync(int id);
    Task<IBaseResponse<bool>> CreateImageAsync(Image image);
    //Task<IBaseResponse<Category>> EditCategory(CategoryViewModel categoryViewModel);
}