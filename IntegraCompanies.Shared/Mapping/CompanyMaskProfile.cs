using AutoMapper;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;

namespace IntegraCompanies.Shared.Mapping
{
    public class CompanyMaskProfile : Profile
    {
        public CompanyMaskProfile()
        {
            CreateMap<CompanyMask, CompanyMaskGrid>();
            CreateMap<CompanyMaskModify, CompanyMask>();
        }
    }
}
