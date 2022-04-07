using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Data.Models
{
    public class CompanyMask
    {
        public Guid CompanyMaskId { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        [MaxLength(10)]
        public string Mask { get; set; }

        public Company Company { get; set; }
    }
}
