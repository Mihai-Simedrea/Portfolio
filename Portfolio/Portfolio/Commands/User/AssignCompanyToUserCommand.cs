using MediatR;
using Microsoft.EntityFrameworkCore;
using Portofolio.Data;

namespace Portofolio.Commands.User
{
    public class AssignCompanyToUserCommand
    {
        public class AssignCompanyToUserCommandRequest : IRequest<int>
        {
            public int? UserId { get; set; }
            public int? CompanyId { get; set; }
        }

        public class AssignCompanyToUserCommandHandler : IRequestHandler<AssignCompanyToUserCommandRequest, int>
        {
            public ApplicationDbContext _applicationDbContext;
            public AssignCompanyToUserCommandHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(AssignCompanyToUserCommandRequest request, CancellationToken cancellationToken)
            {
                var user = await _applicationDbContext.Users
                    .Where(x => x.Id == request.UserId)
                    .FirstOrDefaultAsync(cancellationToken);

                var company = await _applicationDbContext.Companies
                    .Where(x => x.Id == request.CompanyId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (user != null && company != null)
                {
                    user.Company = company;
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return 1;
                }

                return 0;
            }
        }
    }
}
