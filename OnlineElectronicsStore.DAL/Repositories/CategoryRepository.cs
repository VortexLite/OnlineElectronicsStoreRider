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
        // Використовуємо IQueryable для збереження лінивого вирахування та AsNoTracking для оптимізації
        return await _db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Category>> SelectAsync()
    {
        // Використовуємо IQueryable для збереження лінивого вирахування та AsNoTracking для оптимізації
        return await _db.Categories.AsNoTracking().ToListAsync();
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
        // Використовуємо IQueryable для збереження лінивого вирахування та AsNoTracking для оптимізації
        return await _db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
    }
}