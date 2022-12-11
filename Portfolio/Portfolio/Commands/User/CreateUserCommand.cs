using AutoMapper;
using MediatR;
using Portfolio.Data;
using Portfolio.Dtos;

namespace Portfolio.Commands.User
{
    public class CreateUserCommand
    {
        public class CreateUserCommandRequest : IRequest<UserDto>
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Quote { get; set; }
            public string? Email { get; set; }
        }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, UserDto>
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
            {
                var user = new UserDto
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Quote = request.Quote,
                    Email = request.Email
                };

                await _applicationDbContext.Users
                    .AddAsync(_mapper.Map<Entities.User>(user), cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return user;
            }
        }
    }
}
