using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IReviewRepository : IBaseRepository<Review>
{
    Task<List<Review>> GetReviewByProfileAsync(int idProfile);
}