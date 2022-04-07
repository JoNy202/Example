using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Shared.Models
{
    public class ConnectionModify
    {
        [Required]
        public Guid ConnectionStringId { get; set; }
        [Required]
        [MaxLength(250)]
        public string DatabaseName { get; set; }
        public bool IsRazdel { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }
    }
}