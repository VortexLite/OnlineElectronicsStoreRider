using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    public async Task<IBaseResponse<List<Review>>> GetReviewsAsync()
    {
        var baseResponse = new BaseResponse<List<Review>>();
        try
        {
            var reviews = await _reviewRepository.SelectAsync();
            if (reviews.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ReviewElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = reviews;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Review>>()
            {
                Desription = $"[GetReviewAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<List<Review>>> GetReviewByProfileAsync(int idProfile)
    {
        var baseResponse = new BaseResponse<List<Review>>();
        try
        {
            var reviews = await _reviewRepository.GetReviewByProfileAsync(idProfile);
            if (reviews.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ReviewElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = reviews;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Review>>()
            {
                Desription = $"[GetReviewByProfileAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Review>> GetReviewAsync(int id)
    {
        var baseResponse = new BaseResponse<Review>();
        try
        {
            var review = await _reviewRepository.GetAsync(id);
            if (review == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ReviewElementNotFound;
                return baseResponse;
            }

            baseResponse.Data = review;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Review>()
            {
                Desription = $"[GetReviewAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteReviewAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var review = await _reviewRepository.GetAsync(id);
            if (review == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ReviewElementNotFound;
                return baseResponse;
            }

            await _reviewRepository.DeleteAsync(review);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteReviewAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateReviewAsync(Review model)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var review = new Review
            {
                Content = model.Content,
                Rating = model.Rating,
                IdProfile = model.IdProfile,
                IdOrder = model.IdOrder,
                IdCategoryReview = model.IdCategoryReview
            };
            await _reviewRepository.CreateAsync(review);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateReviewAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}