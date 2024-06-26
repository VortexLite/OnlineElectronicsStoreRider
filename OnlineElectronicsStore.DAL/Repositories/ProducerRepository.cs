﻿using Microsoft.EntityFrameworkCore;
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
        return await _db.Producers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Producer>> SelectAsync()
    {
        return await _db.Producers.AsNoTracking().ToListAsync();
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
        // Використовуємо IQueryable для лінивого вирахування та AsNoTracking для оптимізації
        var producers = await _db.Categories
            .Where(c => c.Name == name)
            .SelectMany(c => c.Navigations.Select(n => n.Producer))
            .Distinct()
            .AsNoTracking()
            .ToListAsync();

        return producers;
    }

    public async Task<List<Producer>> NavigationRowsByIdAsync(int id)
    {
        // Використовуємо IQueryable для лінивого вирахування та AsNoTracking для оптимізації
        var producers = await _db.Categories
            .Where(c => c.Id == id)
            .SelectMany(c => c.Navigations.Select(n => n.Producer))
            .Distinct()
            .AsNoTracking()
            .ToListAsync();

        return producers;
    }
}
