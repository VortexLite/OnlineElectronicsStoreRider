using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Account;
using OnlineElectronicsStore.Domain.ViewModels.Product;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IUserService
{
    Task<IBaseResponse<List<User>>> GetUsersAsync();
    Task<IBaseResponse<User>> GetUserAsync(int id);
    Task<IBaseResponse<bool>> DeleteUserAsync(int id);
    Task<IBaseResponse<bool>> CreateUserAsync(RegisterViewModel registerViewModel);
    //Task<IBaseResponse<User>> EditProduct(ProductViewModel productViewModel);
}