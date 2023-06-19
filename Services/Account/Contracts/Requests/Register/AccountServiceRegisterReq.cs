namespace JDPodrozeAPI.Services.Account.Contracts.Requests
{
    public class AccountServiceRegisterReq : IAccountServiceRegisterReq
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool GetToken { get; set; }
    }
}