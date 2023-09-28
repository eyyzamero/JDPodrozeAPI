namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public class ExcursionsServiceGetListRes : IExcursionsServiceGetListRes
    {
        public List<ExcursionsServiceGetListItemRes> Items { get; set; }
    }
}