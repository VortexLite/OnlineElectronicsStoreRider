using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly ApplicationDbContext _db;

    public ProfileRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateAsync(Profile entity)
    {
        await _db.Profiles.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Profile> GetAsync(int id)
    {
        return await _db.Profiles.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Profile>> SelectAsync()
    {
        return await _db.Profiles.ToListAsync();
    }

    public async Task<bool> DeleteAsync(Profile entity)
    {
        _db.Profiles.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Profile> UpdateAsync(Profile entity)
    {
        _db.Profiles.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<int> GetByNameAsync(string? name)
    {
        var profile = await _db.Profiles
            .FirstOrDefaultAsync(i => i.User.Login == name);

        return profile.Id;
    }
}