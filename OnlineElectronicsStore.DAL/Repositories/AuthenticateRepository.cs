using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Repositories;

public class AuthenticateRepository : IAuthenticateRepository
{
    private readonly ApplicationDbContext _db;

    public AuthenticateRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<User> AuthenticateLoginPasswordUserAsync(string login, string password)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
    }

    public async Task<User> AuthenticateLoginUserAsync(string login)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Login == login);
    }
}