using Portofolio.Dtos;
using Portofolio.Entities;

namespace Portofolio.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleId, opts => opts.MapFrom(x => x.RoleId))
                .ForMember(dest => dest.Company, opts => opts.Ignore()).ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
