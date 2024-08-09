using JDPodrozeAPI.Core.DTOs;

namespace JDPodrozeAPI.Core.Repositories
{
    public interface IVisitsRepository
    {
        public Task<int> RegisterAsync(VisitDTO visit);
    }
}