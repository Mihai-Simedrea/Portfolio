using Portfolio.Dtos;
using Portfolio.Entities;
using Portfolio.Dtos;
using Portfolio.Entities;

namespace Portfolio.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleId, opts => opts.MapFrom(x => x.RoleId))
                .ForMember(dest => dest.CompanyId, opts => opts.MapFrom(x => x.CompanyId));
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Collaborator, CollaboratorDto>().ReverseMap();
        }
    }
}
