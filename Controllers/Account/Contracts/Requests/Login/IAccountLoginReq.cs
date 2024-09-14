namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public interface IAccountLoginReq
    {
        public string Login { get; init; }

        public string Password { get; init; }
    }
}