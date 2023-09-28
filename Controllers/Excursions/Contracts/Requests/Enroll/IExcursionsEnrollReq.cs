namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public interface IExcursionsEnrollReq
    {
        int ExcursionId { get; set; }
        ExcursionEnrollPersonReq Booker { get; set; }
        IList<ExcursionEnrollPersonReq>? Participants { get; set; }
        char PaymentMethod { get; set; }
    }
}