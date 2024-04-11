using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _db;
    public OrderRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(Order entity)
    {
        await _db.Orders.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Order> GetAsync(int id)
    {
        return await _db.Orders.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Order>> SelectAsync()
    {
        return await _db.Orders.ToListAsync();
    }

    public async Task<bool> DeleteAsync(Order entity)
    {
        _db.Orders.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Order> UpdateAsync(Order entity)
    {
        _db.Orders.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<List<Order>> GetOrdersWithDeliveryStatusOrderDetailAsync(int idProfile)
    {
        var orders = await _db.Orders
            .Include(i => i.DeliveryType)
            .Include(i => i.StatusDelivery)
            .Include(i => i.OrderDetails)
            .Where(i => i.Profile.Id == idProfile)
            .ToListAsync();

        return orders;
    }
}