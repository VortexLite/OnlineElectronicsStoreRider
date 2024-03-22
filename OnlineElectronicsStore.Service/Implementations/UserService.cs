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

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IBaseResponse<List<User>>> GetUsers()
    {
        var baseResponse = new BaseResponse<List<User>>();
        try
        {
            var users = await _userRepository.Select();
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
                Desription = $"[GetUsers] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<User>> GetUser(int id)
    {
        var baseResponse = new BaseResponse<User>();
        try
        {
            var user = await _userRepository.Get(id);
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
                Desription = $"[GetUser] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteUser(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var user = await _userRepository.Get(id);
            if (user == null)
            {
                baseResponse.Desription = $"Element with id:{id} not found";
                baseResponse.StatusCode = StatusCode.UserNotFound;
                return baseResponse;
            }

            await _userRepository.Delete(user);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[DeleteUser] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> CreateUser(RegisterViewModel registerViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var user = new User()
            {
                Login = registerViewModel.Login,
                Password = registerViewModel.Password
            };

            await _userRepository.Create(user);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Desription = $"[CreateUser] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}