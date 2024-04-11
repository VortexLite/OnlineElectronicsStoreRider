using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(Category entity)
    {
        await _db.Categories.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Category> GetAsync(int id)
    {
        return await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Category>> SelectAsync()
    {
        return await _db.Categories.ToListAsync();
    }

    public async Task<bool> DeleteAsync(Category entity)
    {
        _db.Categories.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Category> UpdateAsync(Category entity)
    {
        _db.Categories.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<Category> GetByNameAsync(string name)
    {
        return await _db.Categories.FirstOrDefaultAsync(x => x.Name == name);
    }
}