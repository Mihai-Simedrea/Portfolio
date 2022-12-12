using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Dtos;
using Portfolio.Data;

namespace Portfolio.Queries
{
    public class GetAllCollaboratorsForCompanyQuery
    {
        public class GetAllCollaboratorsForCompanyQueryRequest : IRequest<IReadOnlyList<int>>
        {
            public int CompanyId { get; set; }
        }

        public class GetAllCollaboratorsForCompanyQueryHandler : IRequestHandler<GetAllCollaboratorsForCompanyQueryRequest, IReadOnlyList<int>>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;

            public GetAllCollaboratorsForCompanyQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<IReadOnlyList<int>> Handle(GetAllCollaboratorsForCompanyQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.CompanyCollaborators
                    .Where(c => c.CompanyId == request.CompanyId)
                    .Select(x => x.CollaboratorId)
                    .ToListAsync(cancellationToken);

                return _mapper.Map<IReadOnlyList<int>>(query);
            }
        }
    }
}