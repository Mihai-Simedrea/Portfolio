using MediatR;
using Microsoft.EntityFrameworkCore;
using Portofolio.Data;

namespace Portofolio.Commands.User
{
    public class AssignRoleToUserCommand
    {
        public class AssignRoleToUserCommandRequest : IRequest<int>
        {
            public int? UserId { get; set; }
            public int? RoleId { get; set; }
        }

        public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommandRequest, int>
        {
            public ApplicationDbContext _applicationDbContext;
            public AssignRoleToUserCommandHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(AssignRoleToUserCommandRequest request, CancellationToken cancellationToken)
            {
                var user = await _applicationDbContext.Users
                    .Where(x => x.Id == request.UserId)
                    .FirstOrDefaultAsync(cancellationToken);

                var role = await _applicationDbContext.Roles
                    .Where(x => x.Id == request.RoleId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (user != null && role != null)
                {
                    user.Role = role;
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return 1;
                }

                return 0;
            }
        }
    }
}
