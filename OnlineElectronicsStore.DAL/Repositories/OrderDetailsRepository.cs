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
    
    public async Task<bool> Create(OrderDetail entity)
    {
        await _db.OrderDetails.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<OrderDetail> Get(int id)
    {
        return await _db.OrderDetails.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<OrderDetail>> Select()
    {
        return await _db.OrderDetails.ToListAsync();
    }

    public async Task<bool> Delete(OrderDetail entity)
    {
        _db.OrderDetails.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<OrderDetail> Update(OrderDetail entity)
    {
        _db.OrderDetails.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}