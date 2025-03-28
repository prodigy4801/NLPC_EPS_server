using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Features.MemberContribution.Command.CreateMemberContribution;
using NLPC_EPS_server.Application.Features.MemberContribution.Command.UpdateMemberContribution;
using NLPC_EPS_server.Application.Features.MemberContribution.Query.GetAllMemberContribution;
using NLPC_EPS_server.Application.Features.MemberContribution.Query.GetMemberContributionDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberContributionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberContributionController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<MemberContributionController>
        [HttpGet]
        public async Task<ActionResult<List<MemberContributionDTO>>> Get()
        {
            var result = await _mediator.Send(new GetMemberContributionQuery());
            return Ok(result);
        }

        // GET api/<MemberContributionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberContributionDetailsDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetMemberContributionDetailsQuery(id));
            return Ok(result);
        }

        // POST api/<MemberContributionController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateMemberContributionCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), response);
        }

        // PUT api/<MemberContributionController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateMemberContributionCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
