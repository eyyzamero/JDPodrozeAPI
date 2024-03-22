using JDPodrozeAPI.Services.Excursions.Enums;

namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public interface IExcursionsGetListReq
    {
        public ExcursionsSortType Sort { get; set; }
        public bool? Active { get; set; }
    }
}