namespace JDPodrozeAPI.Controllers.Account.Contracts.Requests
{
    public interface IAccountAddOrEditReq
    {
        public int? Id { get; }

        public string Login { get; }

        public string? Password { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }
    }
}