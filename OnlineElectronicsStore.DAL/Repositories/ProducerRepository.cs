using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class ProducerRepository : IProducerRepository
{
    private readonly ApplicationDbContext _db;

    public ProducerRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(Producer entity)
    {
        await _db.Producers.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Producer> GetAsync(int id)
    {
        return await _db.Producers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Producer>> SelectAsync()
    {
        return await _db.Producers.ToListAsync();
    }

    public async Task<bool> DeleteAsync(Producer entity)
    {
        _db.Producers.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Producer> UpdateAsync(Producer entity)
    {
        _db.Producers.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<List<Producer>> NavigationByRowsAsync(string name)
    {
        var producers = await _db.Categories
            .Where(c => c.Name == name) // find the category by name
            .SelectMany(c => c.Navigations.Select(n => n.Producer))
            .Distinct()
            .ToListAsync();
        
        return producers;
    }
    
    public async Task<List<Producer>> NavigationRowsByIdAsync(int id)
    {
        var producers = await _db.Categories
            .Where(c => c.Id == id)
            .SelectMany(c => c.Navigations.Select(n => n.Producer))
            .Distinct()
            .ToListAsync();
        
        return producers;
    }
}