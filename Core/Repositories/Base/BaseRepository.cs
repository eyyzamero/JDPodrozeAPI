using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Repositories
{
    public abstract class BaseRepository<TContext> : IBaseRepository where TContext : DbContext
    {
        protected readonly TContext _context;

        protected BaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}