using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Data.Models
{
    public class BillingReport
    {
        public Guid BillingReportId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string FileName { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; }
    }
}
