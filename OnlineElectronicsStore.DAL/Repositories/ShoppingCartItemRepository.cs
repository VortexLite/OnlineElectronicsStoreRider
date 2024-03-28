using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class ShoppingCartItemRepository : IShoppingCartItemRepository
{
    private readonly ApplicationDbContext _db;
    public ShoppingCartItemRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> Create(ShoppingCartItem entity)
    {
        await _db.ShoppingCartItems.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<ShoppingCartItem> Get(int id)
    {
        return await _db.ShoppingCartItems.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ShoppingCartItem>> Select()
    {
        return await _db.ShoppingCartItems.ToListAsync();
    }

    public async Task<bool> Delete(ShoppingCartItem entity)
    {
        _db.ShoppingCartItems.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<ShoppingCartItem> Update(ShoppingCartItem entity)
    {
        _db.ShoppingCartItems.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}