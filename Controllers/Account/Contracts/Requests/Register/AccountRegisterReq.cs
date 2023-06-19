using System.ComponentModel.DataAnnotations;

namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public class AccountRegisterReq : IAccountRegisterReq
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool GetToken { get; set; }
    }
}