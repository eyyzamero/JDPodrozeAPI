namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public interface IExcursionsServiceGetListRes
    {
        public List<ExcursionsServiceGetListItemRes> Items { get; set; }
    }
}