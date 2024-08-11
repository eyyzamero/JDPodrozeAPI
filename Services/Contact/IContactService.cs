using JDPodrozeAPI.Services.Contact.Contracts.Requests;

namespace JDPodrozeAPI.Services
{
    public interface IContactService
    {
        public Task SaveMessageAsync(IContactServiceReq request);
    }
}