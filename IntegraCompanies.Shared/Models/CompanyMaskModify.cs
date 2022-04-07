using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Shared.Models
{
    public class CompanyMaskModify
    {
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        [MaxLength(10)]
        public string Mask { get; set; }
    }
}