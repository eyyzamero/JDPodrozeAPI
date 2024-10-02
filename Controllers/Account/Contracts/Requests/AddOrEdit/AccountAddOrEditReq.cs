namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public record AccountAddOrEditReq : IAccountAddOrEditReq
    {
        public int? Id { get; init; }

        public string Login { get; init; }

        public string? Password { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }
    }
}