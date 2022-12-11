using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Portfolio.Queries.GetAllCollaboratorsQuery;
using static Portfolio.Queries.GetCollaboratorByIdQuery;
using static Portfolio.Commands.User.CreateCollaboratorCommand;

namespace Portofolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CollaboratorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateCollaboratorCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllCollaboratorsQueryRequest());
            return Ok(result);
        }

        [HttpGet]
        [Route("get-{collaboratorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(int collaboratorId)
        {
            var result = await _mediator.Send(new GetCollaboratorByIdQueryRequest()
            {
                CollaboratorId = collaboratorId
            });
            return Ok(result);
        }
    }
}
