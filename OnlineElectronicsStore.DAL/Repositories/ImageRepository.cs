using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly ApplicationDbContext _db;

    public ImageRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(Image entity)
    {
        await _db.Images.AddAsync(entity);
        await _db.SaveChangesAsync();
        
        return true;
    }

    public async Task<Image> GetAsync(int id)
    {
        return await _db.Images.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Image>> SelectAsync()
    {
        return await _db.Images.ToListAsync();
    }

    public async Task<bool> DeleteAsync(Image entity)
    {
        _db.Images.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Image> UpdateAsync(Image entity)
    {
        _db.Images.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> CreateImagesAsync(List<Image> entities)
    {
        await _db.AddRangeAsync(entities);
        await _db.SaveChangesAsync();
        
        return true;
    }
}