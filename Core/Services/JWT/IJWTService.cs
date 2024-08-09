using JDPodrozeAPI.Core.DTOs;

namespace JDPodrozeAPI.Core.Services.JWT
{
    public interface IJWTService
    {
        Task<string> CreateToken(UserDTO user);
    }
}