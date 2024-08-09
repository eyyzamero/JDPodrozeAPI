namespace JDPodrozeAPI.Services.Account.Contracts.Requests
{
    public record AccountServiceLoginReq : IAccountServiceLoginReq
    {
        public string Login { get; init; }
        public string Password { get; init; }
    }
}