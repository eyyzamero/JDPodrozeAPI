namespace JDPodrozeAPI.Controllers.Account.Contracts.Responses
{
    public record AccountRegisterRes : IAccountRegisterRes
    {
        public int Id { get; init; }

        public string Login { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public string Token { get; init; }
    }
}