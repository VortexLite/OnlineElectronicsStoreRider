using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IAuthenticateService 
{
    Task<IBaseResponse<User>> AuthenticateLoginPasswordUserAsync(string login, string password);
    Task<IBaseResponse<User>> AuthenticateLoginUserAsync(string login);
}