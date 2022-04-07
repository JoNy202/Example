using AutoMapper;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;

namespace IntegraCompanies.Shared.Mapping
{
    public class ConnectionProfile : Profile
    {
        public ConnectionProfile()
        {
            CreateMap<Connection, ConnectionGrid>()
                .ForMember(dst => dst.ServerName, opt => opt.MapFrom(src => src.ConnectionServer.Name));
            CreateMap<Connection, ConnectionCombo>()
                .ForMember(dst => dst.ServerName, opt => opt.MapFrom(src => src.ConnectionServer.Name));
            CreateMap<ConnectionModify, Connection>();
        }
    }
}
