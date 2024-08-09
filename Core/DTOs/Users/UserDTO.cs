using System.ComponentModel.DataAnnotations;

namespace JDPodrozeAPI.Core.DTOs
{
    public record UserDTO
    {
        [Key]
        public int Id { get; init; }
        public string Login { get; init; }
        public string Password { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public bool IsAdmin { get; init; }
    }
}