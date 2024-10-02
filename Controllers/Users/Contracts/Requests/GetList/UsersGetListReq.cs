namespace JDPodrozeAPI.Controllers.Users.Contracts.Requests
{
    public record UsersGetListReq : IUsersGetListReq
    {
        public string? SearchText { get; init; }
    }
}