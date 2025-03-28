using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Features.State.Query.GetAllState;
using NLPC_EPS_server.Application.Features.State.Query.GetStateDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StateController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<StateController>
        [HttpGet]

        public async Task<ActionResult<List<StateDTO>>> Get()
        {
            var result = await _mediator.Send(new GetStateQuery());
            return Ok(result);
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StateDetailsDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetStateDetailsQuery(id));
            return Ok(result);
        }
    }
}
