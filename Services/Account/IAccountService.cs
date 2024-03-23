using JDPodrozeAPI.Services.Account.Contracts.Requests;
using JDPodrozeAPI.Services.Account.Contracts.Responses;

namespace JDPodrozeAPI.Services.Account
{
    public interface IAccountService
    {
        string? TryToLogin(IAccountServiceLoginReq request);
        IAccountServiceRegisterRes Register(IAccountServiceRegisterReq request);
        Task<bool> IsLoginAvailable(string login);
    }
}