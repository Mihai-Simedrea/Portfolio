using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Portfolio.Queries.GetAllCompaniesQuery;
using static Portfolio.Queries.GetCompanyByIdQuery;
using static Portfolio.Commands.Collaborator.AssignCompanyToCollaboratorCommand;
using static Portfolio.Commands.Company.CreateCompanyCommand;
using static Portfolio.Commands.User.AssignCompanyToUserCommand;

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


        [HttpPatch]
        [Route("user/{userId}/{companyId}/assign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AssignCompanyToUser(int userId, int companyId)
        {
            var result = await _mediator.Send(new AssignCompanyToUserCommandRequest()
            {
                CompanyId = companyId,
                UserId = userId
            });
            return Ok(result);
        }

        [HttpPatch]
        [Route("company/{companyId}/{collaboratorId}/assign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AssignCollaboratorToCompany(int companyId, int collaboratorId)
        {
            var result = await _mediator.Send(new AssignCompanyToCollaboratorCommandRequest()
            {
                CompanyId = companyId,
                CollaboratorId = collaboratorId
            });
            return Ok(result);
        }
    }
}
