using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Dtos;
using Portfolio.Data;

namespace Portfolio.Queries
{
    public class GetCollaboratorByIdQuery
    {
        public class GetCollaboratorByIdQueryRequest : IRequest<CollaboratorDto>
        {
            public int CollaboratorId { get; set; }
        }

        public class GetCollaboratorByIdQueryHandler : IRequestHandler<GetCollaboratorByIdQueryRequest, CollaboratorDto>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;
            public GetCollaboratorByIdQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<CollaboratorDto> Handle(GetCollaboratorByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Collaborators
                    .Where(x => x.Id == request.CollaboratorId)
                    .FirstOrDefaultAsync();

                return _mapper.Map<CollaboratorDto>(query);
            }
        }
    }
}
