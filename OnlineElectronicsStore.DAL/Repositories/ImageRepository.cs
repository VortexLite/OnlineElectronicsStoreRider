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
    
    public async Task<bool> Create(Image entity)
    {
        await _db.Images.AddAsync(entity);
        await _db.SaveChangesAsync();
        
        return true;
    }

    public async Task<Image> Get(int id)
    {
        return await _db.Images.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Image>> Select()
    {
        return await _db.Images.ToListAsync();
    }

    public async Task<bool> Delete(Image entity)
    {
        _db.Images.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Image> Update(Image entity)
    {
        _db.Images.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}