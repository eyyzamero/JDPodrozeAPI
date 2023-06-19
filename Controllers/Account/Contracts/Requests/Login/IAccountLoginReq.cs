namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public interface IAccountLoginReq
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}