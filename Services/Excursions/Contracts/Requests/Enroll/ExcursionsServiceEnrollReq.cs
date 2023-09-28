using JDPodrozeAPI.Core.Enums;

namespace JDPodrozeAPI.Services.Excursions.Contracts.Requests
{
    public class ExcursionsServiceEnrollReq : IExcursionsServiceEnrollReq
    {
        public int ExcursionId { get; set; }
        public ExcursionsServiceEnrollPersonReq Booker { get; set; }
        public List<ExcursionsServiceEnrollPersonReq> Participants { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}