namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public class ExcursionsServiceGetListShortItemRes : IExcursionsServiceGetListShortItemRes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal PriceGross { get; set; }
        public decimal PriceNet { get; set; }
    }
}