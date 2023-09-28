using JDPodrozeAPI.Core.Enums;

namespace JDPodrozeAPI.Services.Excursions.Contracts.Requests
{
    public interface IExcursionsServiceEnrollReq
    {
        int ExcursionId { get; set; }
        ExcursionsServiceEnrollPersonReq Booker { get; set; }
        List<ExcursionsServiceEnrollPersonReq> Participants { get; set; }
        PaymentMethod PaymentMethod { get; set; }
    }
}