using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Dtos;
using Portfolio.Data;

namespace Portfolio.Queries
{
    public class GetFirstNSectionsQuery
    {
        public class GetFirstNSectionsQueryRequest : IRequest<IReadOnlyList<SectionDto>>
        {
            public int NumberOfSections { get; set; }
        }

        public class GetFirstNSectionsQueryHandler : IRequestHandler<GetFirstNSectionsQueryRequest, IReadOnlyList<SectionDto>>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;

            public GetFirstNSectionsQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<IReadOnlyList<SectionDto>> Handle(GetFirstNSectionsQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Sections
                    .Take(request.NumberOfSections)
                    .ToListAsync(cancellationToken);

                return _mapper.Map<IReadOnlyList<SectionDto>>(query);
            }
        }
    }
}
