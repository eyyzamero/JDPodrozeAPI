using JDPodrozeAPI.Core.Contexts;
using JDPodrozeAPI.Core.DTOs;

namespace JDPodrozeAPI.Core.Repositories.Visits
{
    public class VisitsRepository : BaseRepository<VisitsDbContext>, IVisitsRepository
    {
        public VisitsRepository(VisitsDbContext context) : base(context)
        {
        
        }

        public Task<int> RegisterAsync(VisitDTO visit)
        {
            _context.Visits.Add(visit);
            return _context.SaveChangesAsync();
        }
    }
}