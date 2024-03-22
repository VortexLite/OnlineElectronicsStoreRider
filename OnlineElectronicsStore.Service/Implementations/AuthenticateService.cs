using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Service.Interfaces;

namespace OnlineElectronicsStore.Service.Implementations;

public class AuthenticateService : IAuthenticateService
{
    private readonly IAuthenticateRepository _authenticateRepository;

    public AuthenticateService(IAuthenticateRepository authenticateRepository)
    {
        _authenticateRepository = authenticateRepository;
    }
    public async Task<IBaseResponse<User>> AuthenticateLoginPasswordUser(string login, string password)
    {
        var baseResponse = new BaseResponse<User>();
        try
        {
            var user = await _authenticateRepository.AuthenticateLoginPasswordUser(login, password);
            if (user == null)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.AuthenticateUserNotFound;
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
                Desription = $"[AuthenticateLoginPasswordUser] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<User>> AuthenticateLoginUser(string login)
    {
        var baseResponse = new BaseResponse<User>();
        try
        {
            var user = await _authenticateRepository.AuthenticateLoginUser(login);
            if (user == null)
            {
                baseResponse.Desription = "Found 0 items";
                baseResponse.StatusCode = StatusCode.AuthenticateUserNotFound;
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
                Desription = $"[AuthenticateLoginUser] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}