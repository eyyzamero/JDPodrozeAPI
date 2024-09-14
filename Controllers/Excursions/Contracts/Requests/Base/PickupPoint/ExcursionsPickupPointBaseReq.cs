namespace JDPodrozeAPI.Controllers.Excursions.Contracts.Requests.Base
{
		public abstract record ExcursionsPickupPointBaseReq : IExcursionsPickupPointBaseReq
		{
				public Guid Id { get; init; }

				public string Name { get; init; }
		}
}