namespace JDPodrozeAPI.Services.Contact.Contracts.Requests
{
    public class ContactServiceReq : IContactServiceReq
    {
        public string NameAndSurname { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}