using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _db;
    public ReviewRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(Review entity)
    {
        await _db.Reviews.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Review> GetAsync(int id)
    {
        return await _db.Reviews.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Review>> SelectAsync()
    {
        return await _db.Reviews.ToListAsync();
    }

    public async Task<bool> DeleteAsync(Review entity)
    {
        _db.Reviews.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Review> UpdateAsync(Review entity)
    {
        _db.Reviews.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<List<Review>> GetReviewByProfileAsync(int idProfile)
    {
        var reviews = await _db.Reviews
            .Where(i => i.IdProfile == idProfile)
            .ToListAsync();

        return reviews;
    }
}