using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Dtos;
using Portfolio.Data;

namespace Portfolio.Queries
{
    public class GetAllSectionsQuery
    {
        public class GetAllSectionsQueryRequest : IRequest<IReadOnlyList<SectionDto>>
        {

        }

        public class GetAllSectionsQueryHandler : IRequestHandler<GetAllSectionsQueryRequest, IReadOnlyList<SectionDto>>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;

            public GetAllSectionsQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<IReadOnlyList<SectionDto>> Handle(GetAllSectionsQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Sections
                    .ToListAsync(cancellationToken);

                return _mapper.Map<IReadOnlyList<SectionDto>>(query);
            }
        }
    }
}