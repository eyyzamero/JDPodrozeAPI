namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Responses
{
    public interface IExcursionsGetListShortRes
    {
        public IList<IExcursionsGetListShortItemRes> Items { get; init; }
    }
}