namespace JDPodrozeAPI.Services.Excursions.Contracts.Requests.Base
{
		public abstract record ExcursionsServicePickupPointBaseReq : IExcursionsServicePickupPointBaseReq
		{
				public Guid Id { get; init; }
				public string Name { get; init; }
		}
}