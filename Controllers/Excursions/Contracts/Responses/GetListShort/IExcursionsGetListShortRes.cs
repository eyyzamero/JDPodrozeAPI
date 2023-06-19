namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Responses
{
    public interface IExcursionsGetListShortRes
    {
        public List<ExcursionsGetListShortItemRes> Items { get; set; }
    }
}