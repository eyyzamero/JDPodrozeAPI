namespace JDPodrozeAPI.Services.Users.Contracts.Responses
{
    public interface IUsersGetListRes
    {
        public IEnumerable<IUsersGetListUserRes> Users { get; }
    }
}