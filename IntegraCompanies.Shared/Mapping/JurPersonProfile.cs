using AutoMapper;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;

namespace IntegraCompanies.Shared.Mapping
{
    public class JurPersonProfile : Profile
    {
        public JurPersonProfile()
        {
            CreateMap<JurPerson, JurPersonGrid>();
            CreateMap<JurPerson, JurPersonCombo>();
            CreateMap<JurPersonModify, JurPerson>();
        }
    }
}
