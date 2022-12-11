using AutoMapper;
using MediatR;
using Portfolio.Dtos;
using Portfolio.Entities;
using Portofolio.Data;
using Portofolio.Dtos;
using Portofolio.Entities;

namespace Portofolio.Commands.User
{
    public class CreateCollaboratorCommand
    {
        public class CreateCollaboratorCommandRequest : IRequest<CollaboratorDto>
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Url { get; set; }
        }

        public class CreateCollaboratorCommandHandler : IRequestHandler<CreateCollaboratorCommandRequest, CollaboratorDto>
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;

            public CreateCollaboratorCommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<CollaboratorDto> Handle(CreateCollaboratorCommandRequest request, CancellationToken cancellationToken)
            {
                var collaborator = new CollaboratorDto
                {
                    Name = request.Name,
                    Description = request.Description,
                    Url = request.Url
                };

                await _applicationDbContext.Collaborators
                    .AddAsync(_mapper.Map<Collaborator>(collaborator), cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return collaborator;
            }
        }
    }
}
