using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDPodrozeAPI.Core.DTOs.Newsletter
{
    [Table("NewsletterEmails")]
    public class NewsletterDTO
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}