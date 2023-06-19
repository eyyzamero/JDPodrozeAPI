namespace JDPodrozeAPI.Services.Account.Contracts.Requests
{
    public interface IAccountServiceLoginReq
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}