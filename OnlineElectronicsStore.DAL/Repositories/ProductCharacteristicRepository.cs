using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class ProductCharacteristicRepository : IProductCharacteristicRepository
{
    private readonly ApplicationDbContext _db;
    public ProductCharacteristicRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(ProductCharacteristic entity)
    {
        await _db.ProductCharacteristics.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<ProductCharacteristic> GetAsync(int id)
    {
        return await _db.ProductCharacteristics.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ProductCharacteristic>> SelectAsync()
    {
        return await _db.ProductCharacteristics.ToListAsync();
    }

    public async Task<bool> DeleteAsync(ProductCharacteristic entity)
    {
        _db.ProductCharacteristics.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<ProductCharacteristic> UpdateAsync(ProductCharacteristic entity)
    {
        _db.ProductCharacteristics.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<Category> GetByNameAsync(string name)
    {
        return await _db.Categories.FirstOrDefaultAsync(x => x.Name == name);
    }
}