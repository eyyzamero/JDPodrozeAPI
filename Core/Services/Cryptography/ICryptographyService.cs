namespace JDPodrozeAPI.Core.Services.Cryptography
{
    public interface ICryptographyService
    {
        string Encrypt(string value);
        bool Verify(string value, string hash);
    }
}