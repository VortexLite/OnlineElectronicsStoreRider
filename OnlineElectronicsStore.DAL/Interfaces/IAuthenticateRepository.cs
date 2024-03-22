using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IAuthenticateRepository
{
    Task<User> AuthenticateLoginPasswordUser(string login, string password);
    Task<User> AuthenticateLoginUser(string login);
}