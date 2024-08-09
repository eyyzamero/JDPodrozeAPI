using BCrypt.Net;

namespace JDPodrozeAPI.Core.Services.Cryptography
{
    public class CryptographyService : ICryptographyService
    {
        private readonly IConfiguration _configuration;

        public CryptographyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> EncryptAsync(string value)
        {
            string result = await Task.Run(() => BC.HashPassword(value, _configuration["Cryptography:Salt"], true, HashType.SHA512));
            return result;
        }

        public async Task<bool> VerifyAsync(string value, string hash)
        {
            bool result = await Task.Run(() => BC.Verify(value, hash, true, HashType.SHA512));
            return result;
        }
    }
}