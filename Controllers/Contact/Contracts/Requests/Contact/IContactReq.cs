namespace JDPodrozeAPI.Controllers.Contact.Contracts.Requests
{
    public interface IContactReq
    {
        public string NameAndSurname { get; init; }

        public string Email { get; init; }

        public string Content { get; init; }
    }
}