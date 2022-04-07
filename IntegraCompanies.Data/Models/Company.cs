using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Data.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        [Required]
        public Guid JurPersonId { get; set; }
        [Required]
        public Guid ConnectionId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }

        public JurPerson JurPerson { get; set; }
        public Connection Connection { get; set; }
        public List<CompanyMask> CompanyMasks { get; set; }

        public CompanyCounter CompanyCounter { get; set; }
        public CompanyKvitok CompanyKvitok { get; set; }
        public CompanyGis CompanyGis { get; set; }
    }
}
