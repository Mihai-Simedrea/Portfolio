using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Dtos;
using Portfolio.Data;

namespace Portfolio.Queries
{
    public class GetAllCompaniesQuery
    {
        public class GetAllCompaniesQueryRequest : IRequest<IReadOnlyList<CompanyDto>>
        {

        }

        public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQueryRequest, IReadOnlyList<CompanyDto>>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;

            public GetAllCompaniesQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;   
            }

            public async Task<IReadOnlyList<CompanyDto>> Handle(GetAllCompaniesQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Companies
                    .ToListAsync(cancellationToken);


                return _mapper.Map<IReadOnlyList<CompanyDto>>(query);
            }
        }
    }
}
