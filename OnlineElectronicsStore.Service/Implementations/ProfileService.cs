using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    public async Task<IBaseResponse<List<Profile>>> GetProfiles()
    {
        var baseResponse = new BaseResponse<List<Profile>>();
        try
        {
            var profiles = await _profileRepository.Select();
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
                Desription = $"[GetProfiles] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Profile>> GetProfile(int id)
    {
        var baseResponse = new BaseResponse<Profile>();
        try
        {
            var profile = await _profileRepository.Get(id);
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
                Desription = $"[GetProfile] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteProfile(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var profile = await _profileRepository.Get(id);
            if (profile == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.ProfileUserNotFound;
                return baseResponse;
            }

            await _profileRepository.Delete(profile);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteProfile] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}