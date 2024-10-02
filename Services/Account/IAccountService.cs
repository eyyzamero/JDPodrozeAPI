using JDPodrozeAPI.Controllers.Account.Contracts.Requests;
using JDPodrozeAPI.Services.Account.Contracts.Requests;
using JDPodrozeAPI.Services.Account.Contracts.Responses;

namespace JDPodrozeAPI.Services.Account
{
    public interface IAccountService
    {
        Task<string?> TryToLoginAsync(IAccountServiceLoginReq request);

        Task<IAccountServiceRegisterRes> RegisterAsync(IAccountServiceRegisterReq request);

        Task<bool> IsLoginAvailable(string login, string? currentLogin);

        Task<int?> AddOrEditAsync(IAccountAddOrEditReq request);

        Task DeleteAsync(int id);
    }
}