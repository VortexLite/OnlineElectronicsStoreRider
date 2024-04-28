using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByLoginAsync(string? login);
}