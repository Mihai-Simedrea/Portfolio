using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Dtos;
using Portfolio.Data;

namespace Portfolio.Queries
{
    public class GetCompanyByIdQuery
    {
        public class GetCompanyByIdQueryRequest : IRequest<CompanyDto>
        {
            public int CompanyId { get; set; }
        }

        public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQueryRequest, CompanyDto>
        {
            public ApplicationDbContext _applicationDbContext;
            public IMapper _mapper;
            public GetCompanyByIdHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<CompanyDto> Handle(GetCompanyByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var query = await _applicationDbContext.Companies
                    .Where(x => x.Id == request.CompanyId)
                    .FirstOrDefaultAsync();

                return _mapper.Map<CompanyDto>(query);
            }
        }
    }
}
