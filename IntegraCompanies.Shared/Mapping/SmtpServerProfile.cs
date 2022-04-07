using AutoMapper;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;

namespace IntegraCompanies.Shared.Mapping
{
    public class SmtpServerProfile : Profile
    {
        public SmtpServerProfile()
        {
            CreateMap<SmtpServer, SmtpServerCombo>();
        }
    }
}
