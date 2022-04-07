using AutoMapper;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;

namespace IntegraCompanies.Shared.Mapping
{
    public class BillingReportProfile : Profile
    {
        public BillingReportProfile()
        {
            CreateMap<BillingReport, BillingReportCombo>();
        }
    }
}
