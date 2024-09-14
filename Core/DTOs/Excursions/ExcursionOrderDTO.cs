using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDPodrozeAPI.Core.DTOs.Excursions
{
    public class ExcursionOrderDTO
    {
        [Key]
        public Guid OrderId { get; set; }

        [ForeignKey("Excursion")]
        public int ExcursionId { get; set; }

        public char PaymentMethod { get; set; }

        public char PaymentStatus { get; set; }

        public int BookerId { get; set; }

        public decimal Price { get; set; }

        public Guid? PickupPointId { get; set; }

        public virtual ExcursionDTO Excursion { get; set; }

        public virtual List<ExcursionParticipantDTO> Participants { get; set; }
    }
}