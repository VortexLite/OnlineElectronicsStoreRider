using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> Create(User entity)
    {
        await _db.Users.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<User> Get(int id)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<User>> Select()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<bool> Delete(User entity)
    {
        _db.Users.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<User> Update(User entity)
    {
        _db.Users.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}