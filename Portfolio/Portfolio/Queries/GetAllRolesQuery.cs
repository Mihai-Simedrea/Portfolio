using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Dtos;

namespace Portfolio.Queries
{
    public class GetAllRolesQuery
    {
        public class GetAllRolesQueryRequest : IRequest<IReadOnlyList<RoleDto>>
        {

        }

        public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, IReadOnlyList<RoleDto>>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;

            public GetAllRolesQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<IReadOnlyList<RoleDto>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Roles.ToListAsync(cancellationToken);
                return _mapper.Map<IReadOnlyList<RoleDto>>(query);

            }
        }
    }
}
