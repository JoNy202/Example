using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Data.Models
{
    public class JurPerson
    {
        public Guid JurPersonId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }

        public List<Company> Companys { get; set; }
    }
}
