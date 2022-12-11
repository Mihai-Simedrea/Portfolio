using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Commands.User;
using Portfolio.Dtos;
using Portfolio.Queries;
using static Portfolio.Queries.GetUserByIdQuery;
using static Portfolio.Commands.User.CreateCollaboratorCommand;
using static Portfolio.Commands.User.CreateUserCommand;
using static Portfolio.Queries.GetAllUsersQuery;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllUsersQueryRequest());
            return Ok(result);
        }

        [HttpGet]
        [Route("get-{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = await _mediator.Send(new GetUserByIdQueryRequest()
            {
                UserId = userId
            });
            return Ok(result);
        }
    }
}
