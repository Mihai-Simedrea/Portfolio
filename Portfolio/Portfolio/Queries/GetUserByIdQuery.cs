using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Dtos;

namespace Portfolio.Queries
{
    public class GetUserByIdQuery
    {
        public class GetUserByIdQueryRequest : IRequest<UserDto>
        {
            public int UserId { get; set; }
        }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, UserDto>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;
            public GetUserByIdQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Users
                    .Where(x => x.Id == request.UserId)
                    .FirstOrDefaultAsync(cancellationToken);

                return _mapper.Map<UserDto>(query);
            }
        }
    }
}
