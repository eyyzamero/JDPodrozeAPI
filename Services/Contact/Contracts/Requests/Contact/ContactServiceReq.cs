namespace JDPodrozeAPI.Services.Contact.Contracts.Requests
{
    public record ContactServiceReq : IContactServiceReq
    {
        public string NameAndSurname { get; init; }

        public string Email { get; init; }

        public string Content { get; init; }
    }
}