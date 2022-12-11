using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Dtos;
using Portfolio.Data;

namespace Portfolio.Queries
{
    public class GetAllCollaboratorsQuery
    {
        public class GetAllCollaboratorsQueryRequest : IRequest<IReadOnlyList<CollaboratorDto>>
        {

        }

        public class GetAllCollaboratorsQueryHandler : IRequestHandler<GetAllCollaboratorsQueryRequest, IReadOnlyList<CollaboratorDto>>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;

            public GetAllCollaboratorsQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;   
            }

            public async Task<IReadOnlyList<CollaboratorDto>> Handle(GetAllCollaboratorsQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Collaborators
                    .ToListAsync(cancellationToken);

                return _mapper.Map<IReadOnlyList<CollaboratorDto>>(query);
            }
        }
    }
}
