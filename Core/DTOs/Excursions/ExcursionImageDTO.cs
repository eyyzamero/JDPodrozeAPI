using System.ComponentModel.DataAnnotations;

namespace JDPodrozeAPI.Core.DTOs.Excursions
{
    public class ExcursionImageDTO
    {
        [Key]
        public int Id { get; set; }
        public int ExcursionId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public ExcursionDTO Excursion { get; set; }
    }
}