using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Data.Models
{
    public class SmtpServer
    {
        public Guid SmtpServerId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string SmtpAddress { get; set; }
        [Required]
        public int SmtpPort { get; set; }
        [Required]
        [MaxLength(100)]
        public string SmtpUser { get; set; }
        [Required]
        [MaxLength(100)]
        public string SmtpPassword { get; set; }
        public bool SmtpEnableSsl { get; set; }
    }
}
