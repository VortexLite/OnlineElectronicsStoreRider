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

    public async Task<bool> Create(Navigation entity)
    {
        await _db.Navigations.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Navigation> Get(int id)
    {
        return await _db.Navigations.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Navigation>> Select()
    {
        return await _db.Navigations.ToListAsync();
    }

    public async Task<bool> Delete(Navigation entity)
    {
        _db.Navigations.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Navigation> Update(Navigation entity)
    {
        _db.Navigations.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}