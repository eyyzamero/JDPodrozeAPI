using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDPodrozeAPI.Core.DTOs
{
    public class ExcursionPickupPointDTO
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Excursion")]
        public int ExcursionId { get; set; }

        public string Name { get; set; }

        public virtual ExcursionDTO Excursion { get; set; }
    }
}