using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Account;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IProfileService
{
    Task<IBaseResponse<List<Profile>>> GetProfiles();
    Task<IBaseResponse<Profile>> GetProfile(int id);
    Task<IBaseResponse<bool>> DeleteProfile(int id);
    //Task<IBaseResponse<bool>> CreateProfile(RegisterViewModel registerViewModel);
    //Task<IBaseResponse<User>> EditProduct(ProductViewModel productViewModel);
}