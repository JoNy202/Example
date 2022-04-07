using AutoMapper;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;

namespace IntegraCompanies.Shared.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyGrid>()
                .ForMember(dst => dst.JurName, opt => opt.MapFrom(src => src.JurPerson.Name))
                .ForMember(dst => dst.Connection, opt => opt.MapFrom(src => $"{src.Connection.DatabaseName} ({src.Connection.ConnectionServer.Name})"));
            CreateMap<CompanyModify, Company>();
        }
    }
}
