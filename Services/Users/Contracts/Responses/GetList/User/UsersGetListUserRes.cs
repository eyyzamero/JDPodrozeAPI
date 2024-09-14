namespace JDPodrozeAPI.Services.Users.Contracts.Responses
{
    public record UsersGetListUserRes : IUsersGetListUserRes
    {
        public int Id { get; init; }

        public string Login { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public bool IsAdmin { get; init; }
    }
}