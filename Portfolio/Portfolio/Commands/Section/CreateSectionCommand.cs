using AutoMapper;
using MediatR;
using Portfolio.Data;
using Portfolio.Dtos;

namespace Portfolio.Commands.Section
{
    public class CreateSectionCommand
    {
        public class CreateSectionCommandRequest : IRequest<SectionDto>
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
            public string? Url { get; set; }
            public string? Summary { get; set; }
        }

        public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommandRequest, SectionDto>
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;

            public CreateSectionCommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<SectionDto> Handle(CreateSectionCommandRequest request, CancellationToken cancellationToken)
            {
                var section = new SectionDto
                {
                    Title = request.Title,
                    Description = request.Description,
                    Url = request.Url,
                    Summary = request.Summary
                };

                await _applicationDbContext.Sections
                    .AddAsync(_mapper.Map<Entities.Section>(section), cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return section;
            }
        }
    }
}
