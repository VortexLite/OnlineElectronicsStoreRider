using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IReviewService
{
    Task<IBaseResponse<List<Review>>> GetReviewsAsync();
    Task<IBaseResponse<List<Review>>> GetReviewByProfileAsync(int idProfile);
    Task<IBaseResponse<Review>> GetReviewAsync(int id);
    Task<IBaseResponse<bool>> DeleteReviewAsync(int id);
    Task<IBaseResponse<bool>> CreateReviewAsync(Review model);
    //Task<IBaseResponse<Category>> EditCategoryAsync(CategoryViewModel categoryViewModel);
}