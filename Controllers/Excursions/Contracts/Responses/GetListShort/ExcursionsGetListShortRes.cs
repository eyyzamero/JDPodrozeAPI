namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Responses
{
    public class ExcursionsGetListShortRes : IExcursionsGetListShortRes
    {
        public List<ExcursionsGetListShortItemRes> Items { get; set; }
    }
}