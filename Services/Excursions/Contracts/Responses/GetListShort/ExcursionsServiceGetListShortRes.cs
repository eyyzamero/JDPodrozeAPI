namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public record ExcursionsServiceGetListShortRes : IExcursionsServiceGetListShortRes
    {
        public List<ExcursionsServiceGetListShortItemRes> Items { get; init; }
    }
}