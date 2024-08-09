using System.ComponentModel.DataAnnotations;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public record AccountLoginReq : IAccountLoginReq
    {
        [Required]
        public string Login { get; init; }

        [Required]
        public string Password { get; init; }
    }
}