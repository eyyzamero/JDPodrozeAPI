using JDPodrozeAPI.Core.Enums;

namespace JDPodrozeAPI.Services
{
    public interface IVisitsService
    {
        public Task RegisterAsync(VisitType type, string description);
    }
}