namespace JDPodrozeAPI.Services.Excursions.Contracts.Requests
{
    public class ExcursionsServiceEnrollPersonReq : IExcursionsServiceEnrollPersonReq
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string? TelephoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Discount { get; set; }
    }
}