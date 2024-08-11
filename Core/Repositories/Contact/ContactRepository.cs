using JDPodrozeAPI.Core.Contexts;
using JDPodrozeAPI.Core.DTOs;

namespace JDPodrozeAPI.Core.Repositories
{
    public class ContactRepository : BaseRepository<ContactDbContext>, IContactRepository
    {
        public ContactRepository(ContactDbContext context) : base(context)
        {
        
        }

        public Task AddMessage(ContactDTO message)
        {
            _context.Messages.Add(message);
            return _context.SaveChangesAsync();
        }
    }
}