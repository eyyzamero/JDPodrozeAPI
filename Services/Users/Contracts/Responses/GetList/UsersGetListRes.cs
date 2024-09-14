namespace JDPodrozeAPI.Services.Users.Contracts.Responses
{
    public class UsersGetListRes : IUsersGetListRes
    {
        public IEnumerable<IUsersGetListUserRes> Users { get; init; }
    }
}