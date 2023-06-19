namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public interface IExcursionsServiceGetListShortRes
    {
        public List<ExcursionsServiceGetListShortItemRes> Items { get; set; }
    }
}