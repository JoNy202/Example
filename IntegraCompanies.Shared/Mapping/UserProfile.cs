using AutoMapper;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;

namespace IntegraCompanies.Shared.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGrid>();
            CreateMap<UserModify, User>();
        }
    }
}
