using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portofolio.Data;
using Portofolio.Dtos;

namespace Portofolio.Queries
{
    public class GetRoleByIdQuery
    {
        public class GetRoleByIdQueryRequest : IRequest<RoleDto>
        {
            public int RoleId { get; set; }
        }

        public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQueryRequest, RoleDto>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;

            public GetRoleByIdQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<RoleDto> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Roles
                    .Where(x => x.Id == request.RoleId)
                    .FirstOrDefaultAsync(cancellationToken);

                return _mapper.Map<RoleDto>(query);
            }
        }
    }
}

