namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public class ExcursionsServiceGetListShortRes : IExcursionsServiceGetListShortRes
    {
        public List<ExcursionsServiceGetListShortItemRes> Items { get; set; }
    }
}