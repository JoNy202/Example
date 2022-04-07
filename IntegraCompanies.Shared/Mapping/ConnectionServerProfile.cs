using AutoMapper;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;

namespace IntegraCompanies.Shared.Mapping
{
    public class ConnectionServerProfile : Profile
    {
        public ConnectionServerProfile()
        {
            CreateMap<ConnectionServer, ConnectionServerGrid>();
            CreateMap<ConnectionServer, ConnectionServerCombo>();
            CreateMap<ConnectionServerModify, ConnectionServer>()
                .ForMember(dst => dst.Password, opt => opt.Ignore());
        }
    }
}
