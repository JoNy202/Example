using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Data.Models
{
    public class CompanyKvitok
    {
        public Guid? SmtpServerId { get; set; }
        public Guid? BillingReportId { get; set; }
        [MaxLength(100)]
        public string? FromAddress { get; set; }
        [MaxLength(100)]
        public string? FromName { get; set; }
        public bool KvitokEnabled { get; set; }

        public SmtpServer? SmtpServer { get; set; }
        public BillingReport? BillingReport { get; set; }
    }
}
