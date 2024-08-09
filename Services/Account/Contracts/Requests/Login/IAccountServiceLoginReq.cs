namespace JDPodrozeAPI.Services.Account.Contracts.Requests
{
    public interface IAccountServiceLoginReq
    {
        public string Login { get; init; }
        public string Password { get; init; }
    }
}