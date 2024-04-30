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
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            return null;

        // Використовуємо IQueryable для збереження лінивого вирахування
        IQueryable<User> query = _db.Users
            .Include(u => u.Role)
            .AsNoTracking();

        // Фільтруємо за логіном та паролем, якщо вони передані
        if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
        {
            query = query.Where(u => u.Login == login && u.Password == password);
        }
        else if (!string.IsNullOrWhiteSpace(login))
        {
            query = query.Where(u => u.Login == login);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<User> AuthenticateLoginUserAsync(string login)
    {
        if (string.IsNullOrWhiteSpace(login))
            return null;

        // Використовуємо IQueryable для збереження лінивого вирахування
        IQueryable<User> query = _db.Users
            .Include(u => u.Role)
            .AsNoTracking();

        // Фільтруємо за логіном
        query = query.Where(u => u.Login == login);

        return await query.FirstOrDefaultAsync();
    }
}