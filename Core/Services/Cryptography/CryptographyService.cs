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

        public string Encrypt(string value)
        {
            string result = BC.HashPassword(value, _configuration["Cryptography:Salt"], true, HashType.SHA512);
            return result;
        }

        public bool Verify(string value, string hash)
        {
            bool result = BC.Verify(value, hash, true, HashType.SHA512);
            return result;
        }
    }
}