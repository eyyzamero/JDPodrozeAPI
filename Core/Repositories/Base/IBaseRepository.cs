namespace JDPodrozeAPI.Core.Repositories
{
    public interface IBaseRepository
    {
        public Task<int> SaveChangesAsync();
        public void SaveChanges();
    }
}