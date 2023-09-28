using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDPodrozeAPI.Core.DTOs
{
    [Table("Contact")]
    public class ContactDTO
    {
        [Key]
        public int Id { get; set; }
        public string NameAndSurname { get; set; }
        public string Email { get; set; }
        public string Content{ get; set; }
    }
}