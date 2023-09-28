namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public class ExcursionsEnrollReq : IExcursionsEnrollReq
    {
        public int ExcursionId { get; set; }
        public ExcursionEnrollPersonReq Booker { get; set; }
        public IList<ExcursionEnrollPersonReq>? Participants { get; set; }
        public char PaymentMethod { get; set; }
    }
}