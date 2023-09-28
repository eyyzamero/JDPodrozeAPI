namespace JDPodrozeAPI.Services.Excursions.Exceptions
{
    public class ImageNotFoundException : Exception
    {
        public int HttpStatusCode { get; set; } = (int)System.Net.HttpStatusCode.NotFound;

        public ImageNotFoundException() : base("Image not found")
        {

        }
    }
}