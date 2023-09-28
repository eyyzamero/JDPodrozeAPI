namespace JDPodrozeAPI.Services.Contact.Contracts.Requests
{
    public interface IContactServiceReq
    {
        public string NameAndSurname { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}