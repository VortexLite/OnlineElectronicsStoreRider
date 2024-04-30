using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class NavigationRepository : INavigationRepository
{
    private readonly ApplicationDbContext _db;

    public NavigationRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> CreateAsync(Navigation entity)
    {
        await _db.Navigations.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Navigation> GetAsync(int id)
    {
        // Використовуємо IQueryable для збереження лінивого вирахування та AsNoTracking для оптимізації
        return await _db.Navigations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Navigation>> SelectAsync()
    {
        // Використовуємо IQueryable для збереження лінивого вирахування та AsNoTracking для оптимізації
        return await _db.Navigations.AsNoTracking().ToListAsync();
    }

    public async Task<bool> DeleteAsync(Navigation entity)
    {
        _db.Navigations.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Navigation> UpdateAsync(Navigation entity)
    {
        _db.Navigations.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
