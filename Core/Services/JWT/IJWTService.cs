using JDPodrozeAPI.Core.DTOs.Users;

namespace JDPodrozeAPI.Core.Services.JWT
{
    public interface IJWTService
    {
        string CreateToken(UserDTO user);
    }
}