using System.ComponentModel.DataAnnotations;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public class AccountIsLoginAvailableReq : IAccountIsLoginAvailableReq
    {
        [Required]
        public string Login { get; set; }
    }
}