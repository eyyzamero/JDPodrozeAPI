using AutoMapper;
using JDPodrozeAPI.Core.Contexts.Excursions;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;

namespace JDPodrozeAPI.Services.Excursions
{
    public class ExcursionsService : IExcursionsService
    {
        private readonly IMapper _mapper;
        private readonly ExcursionsDbContext _excursionsDbContext;

        public ExcursionsService(IMapper mapper, ExcursionsDbContext excursionsDbContext)
        {
            _mapper = mapper;
            _excursionsDbContext = excursionsDbContext;
        }

        public IExcursionsServiceGetListShortRes GetListShort()
        {
            IList<ExcursionDTO> excursions = _excursionsDbContext.Excursions.Where(x => x.Active).ToList();
            IExcursionsServiceGetListShortRes response = _mapper.Map<ExcursionsServiceGetListShortRes>(excursions);
            return response;
        }
    }
}