using JDPodrozeAPI.Core.Enums;

namespace JDPodrozeAPI.Services
{
    public interface IVisitsService
    {
        public Task Register(VisitType type, string description);
    }
}