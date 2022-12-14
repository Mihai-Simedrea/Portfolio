using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Commands.Role;
using Portfolio.Dtos;
using Portfolio.Queries;
using static Portfolio.Commands.Section.CreateSectionCommand;
using static Portfolio.Queries.GetAllSectionsQuery;
using static Portfolio.Queries.GetFirstNSectionsQuery;
using static Portfolio.Queries.GetSectionByIdQuery;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateSectionCommandRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllSectionsQueryRequest());
            return Ok(result);
        }


        [HttpGet]
        [Route("get-{sectionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSectionById(int sectionId)
        {
            var result = await _mediator.Send(new GetSectionByIdQueryRequest()
            {
                SectionId = sectionId
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("first-n-sections-{numberOfSections}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFirstNSections(int numberOfSections)
        {
            var result = await _mediator.Send(new GetFirstNSectionsQueryRequest()
            {
                NumberOfSections = numberOfSections
            });
            return Ok(result);
        }
    }
}
