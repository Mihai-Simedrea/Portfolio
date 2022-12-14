using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Dtos;
using Portfolio.Data;

namespace Portfolio.Queries
{
    public class GetSectionByIdQuery
    {
        public class GetSectionByIdQueryRequest : IRequest<SectionDto>
        {
            public int SectionId { get; set; }
        }

        public class GetSectionByIdQueryHandler : IRequestHandler<GetSectionByIdQueryRequest, SectionDto>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;

            public GetSectionByIdQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<SectionDto> Handle(GetSectionByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var section = await _applicationDbContext.Sections
                    .Where(x => x.Id == request.SectionId)
                    .SingleOrDefaultAsync(cancellationToken);

                return _mapper.Map<SectionDto>(section);
            }
        }
    }
}