using AutoMapper;
using IntegraCompanies.Api.Resources;
using IntegraCompanies.Data.Models;

namespace IntegraCompanies.Api.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyResource>()
                .ForMember(dest => dest.Masks, opt => opt.MapFrom(src => src.CompanyMasks.Select(x => x.Mask).ToList()));

            CreateMap<Connection, ConnectionResource>()
                .IncludeMembers(s => s.ConnectionServer);

            CreateMap<ConnectionServer, ConnectionResource>();
        }
    }
}
