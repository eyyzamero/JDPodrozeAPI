namespace JDPodrozeAPI.Core.Services.Cryptography
{
    public interface ICryptographyService
    {
        Task<string> EncryptAsync(string value);
        Task<bool> VerifyAsync(string value, string hash);
    }
}