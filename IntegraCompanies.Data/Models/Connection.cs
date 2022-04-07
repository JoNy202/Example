using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Data.Models
{
    public class Connection
    {
        public Guid ConnectionId { get; set; }
        [Required]
        public Guid ConnectionServerId { get; set; }
        [Required]
        [MaxLength(250)]
        public string DatabaseName { get; set; }
        public bool IsRazdel { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }

        public ConnectionServer ConnectionServer { get; set; }
    }
}
