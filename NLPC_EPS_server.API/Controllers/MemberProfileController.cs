using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Features.MemberProfile.Command.CreateMemberProfile;
using NLPC_EPS_server.Application.Features.MemberProfile.Command.UpdateMemberProfile;
using NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile;
using NLPC_EPS_server.Application.Features.MemberProfile.Query.GetMemberProfileDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberProfileController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<MemberProfileController>
        [HttpGet]
        public async Task<ActionResult<List<MemberProfileDTO>>> Get()
        {
            var result = await _mediator.Send(new GetMemberProfileQuery());
            return Ok(result);
        }

        // GET api/<MemberProfileController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberProfileDetailsDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetMemberProfileDetailsQuery(id));
            return Ok(result);
        }

        // POST api/<MemberProfileController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateMemberProfileCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), response);
        }

        // PUT api/<MemberProfileController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateMemberProfileCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
