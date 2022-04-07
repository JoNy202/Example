using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Shared.Models
{
    public class ConnectionServerModify
    {
        public Guid ConnectionServerId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Source { get; set; }
        [Required]
        [MaxLength(100)]
        public string User { get; set; }
        [MaxLength(50)]
        public string? Password { get; set; }
    }
}