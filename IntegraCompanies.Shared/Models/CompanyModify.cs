using IntegraCompanies.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Shared.Models
{
    public class CompanyModify
    {
        [Required]
        public Guid JurPersonId { get; set; }
        [Required]
        public Guid ConnectionId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }

        public CompanyCounter CompanyCounter { get; set; }
        public CompanyKvitok CompanyKvitok { get; set; }
        public CompanyGis CompanyGis { get; set; }
    }
}