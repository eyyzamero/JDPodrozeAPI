using JDPodrozeAPI.Core.DTOs;

namespace JDPodrozeAPI.Core.Repositories
{
    public interface IContactRepository
    {
        public Task AddMessage(ContactDTO message);
    }
}