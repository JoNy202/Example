using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Shared.Models
{
    public class JurPersonModify
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }
    }
}