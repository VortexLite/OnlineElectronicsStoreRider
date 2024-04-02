using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class WishListRepository : IWishListRepository
{
    private readonly ApplicationDbContext _db;
    public WishListRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> Create(WishList entity)
    {
        await _db.WishLists.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<WishList> Get(int id)
    {
        return await _db.WishLists.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<WishList>> Select()
    {
        return await _db.WishLists.ToListAsync();
    }

    public async Task<bool> Delete(WishList entity)
    {
        _db.WishLists.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<WishList> Update(WishList entity)
    {
        _db.WishLists.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}