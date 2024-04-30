using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class DeliveryTypeRepository : IDeliveryTypeRepository
{
    private readonly ApplicationDbContext _db;
    public DeliveryTypeRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(DeliveryType entity)
    {
        await _db.DeliveryTypes.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<DeliveryType> GetAsync(int id)
    {
        // Використовуємо IQueryable для збереження лінивого вирахування та AsNoTracking для оптимізації
        return await _db.DeliveryTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<DeliveryType>> SelectAsync()
    {
        // Використовуємо IQueryable для збереження лінивого вирахування та AsNoTracking для оптимізації
        return await _db.DeliveryTypes.AsNoTracking().ToListAsync();
    }

    public async Task<bool> DeleteAsync(DeliveryType entity)
    {
        _db.DeliveryTypes.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<DeliveryType> UpdateAsync(DeliveryType entity)
    {
        _db.DeliveryTypes.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}