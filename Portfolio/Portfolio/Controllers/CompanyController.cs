using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Queries;
using Portofolio.Commands.Company;
using Portofolio.Commands.User;
using Portofolio.Dtos;
using Portofolio.Queries;
using static Portfolio.Queries.GetAllCompaniesQuery;
using static Portfolio.Queries.GetCompanyByIdQuery;
using static Portfolio.Queries.GetUserByIdQuery;
using static Portofolio.Commands.Company.CreateCompanyCommand;
using static Portofolio.Queries.GetAllUsersQuery;

namespace Portofolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllCompaniesQueryRequest());
            return Ok(result);
        }

        [HttpGet]
        [Route("get-{companyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(int companyId)
        {
            var result = await _mediator.Send(new GetCompanyByIdQueryRequest()
            {
                CompanyId = companyId
            });
            return Ok(result);
        }
    }
}
