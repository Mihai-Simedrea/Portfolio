using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portofolio.Data;
using Portofolio.Dtos;

namespace Portofolio.Queries
{
    public class GetAllUsersQuery
    {
        public class GetAllUsersQueryRequest : IRequest<IReadOnlyList<UserDto>>
        {

        }

        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, IReadOnlyList<UserDto>>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;

            public GetAllUsersQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<IReadOnlyList<UserDto>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Users.ToListAsync(cancellationToken);
                return _mapper.Map<IReadOnlyList<UserDto>>(query);

            }
        }
    }
}
