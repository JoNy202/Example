using System.ComponentModel.DataAnnotations;

namespace IntegraCompanies.Data.Models
{
    public class CompanyGis
    {
        public Guid? OrgPPAGUID { get; set; }
        public bool DebtEnabled { get; set; }
        public int DebtProcessType { get; set; }
    }
}
