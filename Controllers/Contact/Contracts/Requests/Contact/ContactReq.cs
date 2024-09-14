namespace JDPodrozeAPI.Controllers.Contact.Contracts.Requests
{
    public record ContactReq : IContactReq
    {
        public string NameAndSurname { get; init; }

        public string Email { get; init; }

        public string Content { get; init; }
    }
}