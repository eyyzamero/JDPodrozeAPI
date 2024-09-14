namespace JDPodrozeAPI.Services.Users.Contracts.Responses
{
    public interface IUsersGetListUserRes
    {
        public int Id { get; }

        public string Login { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public bool IsAdmin { get; }
    }
}