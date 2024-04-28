using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Account;
using OnlineElectronicsStore.Domain.ViewModels.OrderViewModel;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IProfileService
{
    Task<IBaseResponse<List<Profile>>> GetProfilesAsync();
    Task<IBaseResponse<Profile>> GetProfileAsync(int id);
    Task<IBaseResponse<int>> GetByNameAsync(string? name);
    Task<IBaseResponse<bool>> DeleteProfileAsync(int id);
    Task<IBaseResponse<bool>> EditProfileAsync(Profile model);
    //Task<IBaseResponse<bool>> CreateProfileAsync(RegisterViewModel registerViewModel);
    Task<IBaseResponse<bool>> EditProfileByContactAsync(ContactViewModel contactViewModel, int id);
}