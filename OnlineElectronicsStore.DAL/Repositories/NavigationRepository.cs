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

    public async Task<List<string>> NavigationByRows(string name)
    {
        var category = await _db.Categories
            .Where(c => c.Name == name)
            .Select(c => c.Id)
            .FirstOrDefaultAsync();

        int categoryConvert = Convert.ToInt32(category);
        
        var producer = await _db.Navigations
            .Where(n => n.IdCategory == categoryConvert)
            .Select(n => n.Producer.Name)
            .Distinct()
            .ToListAsync();
        
        return producer;
    }
    
    public async Task<List<string>> NavigationRowsById(int id)
    {
        var producer = await _db.Navigations
            .Where(n => n.IdCategory == id)
            .Select(n => n.Producer.Name)
            .Distinct()
            .ToListAsync();
        
        return producer;
    }
}