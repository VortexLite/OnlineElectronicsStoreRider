using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.OrderViewModel;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    public async Task<IBaseResponse<List<Profile>>> GetProfilesAsync()
    {
        var baseResponse = new BaseResponse<List<Profile>>();
        try
        {
            var profiles = await _profileRepository.SelectAsync();
            if (profiles.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.ProfileUserNotFound;
                return baseResponse;
            }

            baseResponse.Data = profiles;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Profile>>()
            {
                Desription = $"[GetProfilesAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Profile>> GetProfileAsync(int id)
    {
        var baseResponse = new BaseResponse<Profile>();
        try
        {
            var profile = await _profileRepository.GetAsync(id);
            if (profile == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProfileUserNotFound;
                return baseResponse;
            }

            baseResponse.Data = profile;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Profile>()
            {
                Desription = $"[GetProfileAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<int>> GetByNameAsync(string? name)
    {
        var baseResponse = new BaseResponse<int>();
        try
        {
            var profile = await _profileRepository.GetByNameAsync(name);
            if (profile == null)
            {
                baseResponse.Desription = $"Element with name:{name} not found";
                baseResponse.StatusCode = StatusCode.ProfileUserNotFound;
                return baseResponse;
            }

            baseResponse.Data = profile;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<int>()
            {
                Desription = $"[GetByNameAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProfileAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var profile = await _profileRepository.GetAsync(id);
            if (profile == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProfileUserNotFound;
                return baseResponse;
            }

            await _profileRepository.DeleteAsync(profile);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteProfileAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> EditProfileByContactAsync(ContactViewModel contactViewModel, int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var profile = await _profileRepository.GetAsync(id);
            if (profile == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProfileUserNotFound;
                return baseResponse;
            }

            profile.Name = contactViewModel.FirstName;
            profile.Surname = contactViewModel.LastName;
            profile.Phone = contactViewModel.PhoneNumber;

            await _profileRepository.UpdateAsync(profile);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[EditProfileByIdAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}