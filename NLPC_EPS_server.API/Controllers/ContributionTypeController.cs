using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Features.ContributionType.Query.GetAllContributionType;
using NLPC_EPS_server.Application.Features.ContributionType.Query.GetContributionTypeDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContributionTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<ContributionTypeController>
        [HttpGet]

        public async Task<ActionResult<List<ContributionTypeDTO>>> Get()
        {
            var result = await _mediator.Send(new GetContributionTypeQuery());
            return Ok(result);
        }

        // GET api/<ContributionTypeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContributionTypeDetailsDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetContributionTypeDetailsQuery(id));
            return Ok(result);
        }
    }
}
