namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Responses
{
    public interface IExcursionsGetListShortItemRes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal PriceGross { get; set; }
        public decimal PriceNet { get; set; }
    }
}