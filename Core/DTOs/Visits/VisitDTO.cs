using System.ComponentModel.DataAnnotations;

namespace JDPodrozeAPI.Core.DTOs
{
    public class VisitDTO
    {
        [Key]
        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}