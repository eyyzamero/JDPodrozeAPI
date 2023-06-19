using System.ComponentModel.DataAnnotations;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public class AccountLoginReq
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}