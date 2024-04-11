using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Account;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IProfileRepository _profileRepository;

    public UserService(IUserRepository userRepository, IProfileRepository profileRepository)
    {
        _userRepository = userRepository;
        _profileRepository = profileRepository;
    }
    public async Task<IBaseResponse<List<User>>> GetUsersAsync()
    {
        var baseResponse = new BaseResponse<List<User>>();
        try
        {
            var users = await _userRepository.SelectAsync();
            if (users.Count == 0)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.UserNotFound;
                return baseResponse;
            }

            baseResponse.Data = users;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<User>>()
            {
                Desription = $"[GetUsersAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<User>> GetUserAsync(int id)
    {
        var baseResponse = new BaseResponse<User>();
        try
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.UserNotFound;
                return baseResponse;
            }

            baseResponse.Data = user;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<User>()
            {
                Desription = $"[GetUserAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteUserAsync(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.UserNotFound;
                return baseResponse;
            }

            await _userRepository.DeleteAsync(user);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteUserAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateUserAsync(RegisterViewModel registerViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var user = new User()
            {
                Login = registerViewModel.Login,
                Password = registerViewModel.Password,
                IdRole = 3
            };

            var profile = new Profile
            {
                Name = null,
                Surname = null,
                Middlename = null,
                Phone = null,
                Email = registerViewModel.Email,
                Address = null
            };

            await _profileRepository.CreateAsync(profile);
            
            user.IdProfile = profile.Id;
            
            await _userRepository.CreateAsync(user);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateUserAsync] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}