using AutoMapper;
using p1.DTO;
using p1.Entities;

namespace p1.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, GetMembersDto>();
            CreateMap<User, UDto>();
            CreateMap<DebtReg , DebtDto>();
        }
    }
}
