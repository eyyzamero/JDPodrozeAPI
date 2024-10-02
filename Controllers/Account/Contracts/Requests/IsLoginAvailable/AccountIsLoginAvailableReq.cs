using System.ComponentModel.DataAnnotations;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public record AccountIsLoginAvailableReq : IAccountIsLoginAvailableReq
    {
        [Required]
        public string Login { get; init; }

        public string? CurrentLogin { get; init; }
    }
}