using AutoMapper;
using MediatR;
using Portfolio.Dtos;
using Portfolio.Data;
using Portfolio.Dtos;
using Portfolio.Entities;

namespace Portfolio.Commands.Company
{
    public class CreateCompanyCommand
    {
        public class CreateCompanyCommandRequest : IRequest<CompanyDto>
        {
            public string? Name { get; set; }
        }

        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CompanyDto>
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly IMapper _mapper;

            public CreateCompanyCommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _applicationDbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<CompanyDto> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
            {
                var company = new CompanyDto
                {
                    Name = request.Name
                };

                await _applicationDbContext.Companies
                    .AddAsync(_mapper.Map<Entities.Company>(company), cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return company;
            }
        }
    }
}
