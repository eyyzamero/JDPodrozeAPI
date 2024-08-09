using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace JDPodrozeAPI.Services
{
    public class ImagesService : IImagesService
    {
        private readonly (int width, int height, string name)[] _resolutions = new (int width, int height, string name)[]
        {
            (640, 360, "nHD"),
            (854, 480, "FWVGA"),
            (960, 540, "qHD"),
            (1024, 576, "WSVGA"),
            (1280, 720, "HD")
        };

        public async Task<byte[]> GetImageAsync(string path, int fileId, string resolution, string extension)
        {
            string basePath = Path.Combine($"Images/{path}/{resolution}/{fileId}", $"{fileId}.{extension}");
            byte[] imageBytes = await File.ReadAllBytesAsync(basePath);
            return imageBytes;
        }

        public async Task ProcessImageAsync(byte[] imageBytes, string path, string fileName)
        {
            using (var image = Image.Load(imageBytes))
            {
                foreach (var (width, height, name) in _resolutions)
                {
                    var resizedImage = image.Clone(ctx => ctx.Resize(width, height));
                    string basePath = Path.Combine($"Images/{path}/{name}", fileName);
                    Directory.CreateDirectory(basePath);

                    string pngPath = Path.Combine(basePath, $"{fileName}.png");
                    string webpPath = Path.Combine(basePath, $"{fileName}.webp");

                    await _SaveImageAsync(resizedImage, pngPath, new PngEncoder());
                    await _SaveImageAsync(resizedImage, webpPath, new WebpEncoder());
                }
            }
        }

        public async Task DeleteImagesAsync(string path, int id)
        {
            string basePath = Path.Combine($"Images/{path}");

            foreach(var resolution in _resolutions)
            {
                string imagePath = Path.Combine(basePath, $"{resolution.name}/{id}");

                if (Directory.Exists(imagePath))
                    Directory.Delete(imagePath, true);
                else
                    throw new DirectoryNotFoundException($"Directory not found: {imagePath}");
            }
            await Task.CompletedTask;
        }

        private async Task _SaveImageAsync(Image image, string path, IImageEncoder encoder)
        {
            using var fileStream = new FileStream(path, FileMode.Create);
                await image.SaveAsync(fileStream, encoder);
        }
    }
}