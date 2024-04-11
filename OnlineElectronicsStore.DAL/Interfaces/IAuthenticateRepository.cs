using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IAuthenticateRepository
{
    Task<User> AuthenticateLoginPasswordUserAsync(string login, string password);
    Task<User> AuthenticateLoginUserAsync(string login);
}