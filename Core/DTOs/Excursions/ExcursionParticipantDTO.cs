using JDPodrozeAPI.Core.DTOs.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDPodrozeAPI.Core.DTOs.Excursions
{
    public class ExcursionParticipantDTO
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public int? BookerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Discount { get; set; }
        public string? Email { get; set; }
        public string? TelephoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public UserDTO? User { get; set; }
        public ExcursionOrderDTO Order { get; set; }
    }
}