using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portofolio.Commands.Role;
using Portofolio.Dtos;
using Portofolio.Queries;
using static Portofolio.Commands.Role.CreateRoleCommand;
using static Portofolio.Commands.User.AssignRoleToUserCommand;
using static Portofolio.Queries.GetAllRolesQuery;
using static Portofolio.Queries.GetRoleByIdQuery;

namespace Portofolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllRolesQueryRequest());
            return Ok(result);
        }

        [HttpPatch]
        [Route("assign-to-{userId}-{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AssignRoleToUser(int userId, int roleId)
        {
            var result = await _mediator.Send(new AssignRoleToUserCommandRequest()
            {
                RoleId = roleId,
                UserId = userId
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("get-{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            var result = await _mediator.Send(new GetRoleByIdQueryRequest()
            {
                RoleId = roleId
            });
            return Ok(result);
        }
    }
}
