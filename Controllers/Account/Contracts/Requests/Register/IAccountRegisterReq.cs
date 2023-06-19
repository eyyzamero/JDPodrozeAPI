namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public interface IAccountRegisterReq
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool GetToken { get; set; }
    }
}