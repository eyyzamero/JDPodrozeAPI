namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public interface IAccountIsLoginAvailableReq
    {
        public string Login { get; }

        public string? CurrentLogin { get; }
    }
}