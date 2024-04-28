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
    
    public async Task<bool> CreateAsync(User entity)
    {
        await _db.Users.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<User> GetAsync(int id)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<User>> SelectAsync()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<bool> DeleteAsync(User entity)
    {
        _db.Users.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<User> UpdateAsync(User entity)
    {
        _db.Users.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<User> GetByLoginAsync(string? login)
    {
        return await _db.Users
            .Include(i => i.Role)
            .FirstOrDefaultAsync(i => i.Login == login);
    }
}