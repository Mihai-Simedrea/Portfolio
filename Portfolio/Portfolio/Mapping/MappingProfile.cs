using Portfolio.Dtos;
using Portfolio.Entities;

namespace Portfolio.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Collaborator, CollaboratorDto>().ReverseMap();
        }
    }
}
