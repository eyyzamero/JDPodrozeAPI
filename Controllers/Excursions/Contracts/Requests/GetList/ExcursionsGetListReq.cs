using JDPodrozeAPI.Services.Excursions.Enums;

namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public class ExcursionsGetListReq : IExcursionsGetListReq
    {
        public ExcursionsSortType Sort { get; set; }
        public bool? Active { get; set; }
        public bool? Templates { get; set; }
    }
}