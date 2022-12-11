using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;
using Portfolio.Data;

namespace Portfolio.Commands.Collaborator
{
    public class AssignCompanyToCollaboratorCommand
    {
        public class AssignCompanyToCollaboratorCommandRequest : IRequest<int>
        {
            public int CollaboratorId { get; set; }
            public int CompanyId { get; set; }
        }

        public class AssignCompanyToCollaboratorCommandHandler : IRequestHandler<AssignCompanyToCollaboratorCommandRequest, int>
        {
            public ApplicationDbContext _applicationDbContext;
            public AssignCompanyToCollaboratorCommandHandler(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<int> Handle(AssignCompanyToCollaboratorCommandRequest request, CancellationToken cancellationToken)
            {
                var collaborator = await _applicationDbContext.Collaborators
                    .Where(x => x.Id == request.CollaboratorId)
                    .FirstOrDefaultAsync(cancellationToken);

                var company = await _applicationDbContext.Companies
                    .Where(x => x.Id == request.CompanyId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (collaborator != null && company != null)
                {
                    var companyCollaborator = new CompanyCollaborator
                    {
                        CompanyId = request.CompanyId,
                        CollaboratorId = request.CollaboratorId
                    };

                    await _applicationDbContext.CompanyCollaborators.
                        AddAsync(companyCollaborator, cancellationToken);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return 1;
                }

                return 0;
            }
        }
    }
}