namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests
{
    public interface IExcursionEnrollPersonReq
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string? TelephoneNumber { get; set; }
        public string BirthDate { get; set; }
        public bool Discount { get; set; }
    }
}