using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IAuthenticateService 
{
    Task<IBaseResponse<User>> AuthenticateLoginPasswordUser(string login, string password);
    Task<IBaseResponse<User>> AuthenticateLoginUser(string login);
}