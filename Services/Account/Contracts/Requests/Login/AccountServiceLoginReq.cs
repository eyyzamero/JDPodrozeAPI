namespace JDPodrozeAPI.Services.Account.Contracts.Requests
{
    public class AccountServiceLoginReq : IAccountServiceLoginReq
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}