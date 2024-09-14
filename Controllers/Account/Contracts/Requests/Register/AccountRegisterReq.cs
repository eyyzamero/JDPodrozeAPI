namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public record AccountRegisterReq : IAccountRegisterReq
    {
        public string Login { get; init; }

        public string Password { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public bool GetToken { get; init; }
    }
}