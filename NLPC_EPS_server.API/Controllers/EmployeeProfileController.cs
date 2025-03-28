using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Command.CreateEmployeeProfile;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Command.UpdateEmployeeProfile;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetEmployeeProfileDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeProfileController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<EmployeeProfileController>
        [HttpGet]
        public async Task<ActionResult<List<EmployeeProfileDTO>>> Get()
        {
            var result = await _mediator.Send(new GetEmployeeProfileQuery());
            return Ok(result);
        }

        // GET api/<EmployeeProfileController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeProfileDetailsDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetEmployeeProfileDetailsQuery(id));
            return Ok(result);
        }

        // POST api/<EmployeeProfileController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateEmployeeProfileCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), response);
        }

        // PUT api/<EmployeeProfileController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateEmployeeProfileCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
