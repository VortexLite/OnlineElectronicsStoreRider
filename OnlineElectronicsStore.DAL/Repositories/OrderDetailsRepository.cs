using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly ApplicationDbContext _db;
    public OrderDetailsRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(OrderDetail entity)
    {
        await _db.OrderDetails.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<OrderDetail> GetAsync(int id)
    {
        return await _db.OrderDetails.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<OrderDetail>> SelectAsync()
    {
        return await _db.OrderDetails.ToListAsync();
    }

    public async Task<bool> DeleteAsync(OrderDetail entity)
    {
        _db.OrderDetails.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<OrderDetail> UpdateAsync(OrderDetail entity)
    {
        _db.OrderDetails.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}