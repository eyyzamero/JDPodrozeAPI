namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Responses
{
    public record ExcursionsGetListShortRes : IExcursionsGetListShortRes
    {
        public IList<IExcursionsGetListShortItemRes> Items { get; init; }
    }
}