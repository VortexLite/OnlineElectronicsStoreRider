using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Account;
using OnlineElectronicsStore.Domain.ViewModels.Product;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IUserService
{
    Task<IBaseResponse<List<User>>> GetUsers();
    Task<IBaseResponse<User>> GetUser(int id);
    Task<IBaseResponse<bool>> DeleteUser(int id);
    Task<IBaseResponse<bool>> CreateUser(RegisterViewModel registerViewModel);
    //Task<IBaseResponse<User>> EditProduct(ProductViewModel productViewModel);
}