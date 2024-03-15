using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;


namespace OnlineElectronicsStore.Service.Interfaces;

public interface IImageService
{
    Task<IBaseResponse<List<Image>>> GetImages();
    Task<IBaseResponse<Image>> GetImage(int id);
    Task<IBaseResponse<bool>> DeleteImage(int id);
    Task<IBaseResponse<bool>> CreateImage(Image image);
    //Task<IBaseResponse<Category>> EditCategory(CategoryViewModel categoryViewModel);
}