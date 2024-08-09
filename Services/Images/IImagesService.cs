namespace JDPodrozeAPI.Services
{
    public interface IImagesService
    {
        public Task<byte[]> GetImageAsync(string path, int fileId, string resolution, string extension);
        public Task ProcessImageAsync(byte[] imageBytes, string path, string fileName);
        public Task DeleteImagesAsync(string path, int id);
    }
}