namespace JDPodrozeAPI.Services
{
    public interface IEmailsService
    {
        public void SendEmail(string email, string senderDetails, string subject, string body, bool includeLogo);
    }
}