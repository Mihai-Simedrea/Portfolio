using AutoMapper;
using MediatR;
using Portofolio.Data;
using Portofolio.Dtos;
using Portofolio.Entities;

namespace Portofolio.Commands.Role
{
    public class CreateRoleCommand
    {
        public class CreateRoleCommandRequest : IRequest<RoleDto>
        {
            public string? Name { get; set; }
        }

        public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, RoleDto>
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;

            public CreateRoleCommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<RoleDto> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
            {
                var role = new RoleDto
                {
                    Name = request.Name
                };

                await _applicationDbContext.Roles
                    .AddAsync(_mapper.Map<Entities.Role>(role), cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return role;
            }
        }
    }
}
