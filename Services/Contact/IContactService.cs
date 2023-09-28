using JDPodrozeAPI.Services.Contact.Contracts.Requests;

namespace JDPodrozeAPI.Services
{
    public interface IContactService
    {
        public void SaveMessage(IContactServiceReq request);
    }
}