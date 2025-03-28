using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.UpdateBenefitRequest;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetBenefitRequestDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BenefitRequestController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<BenefitRequestController>
        [HttpGet]
        public async Task<ActionResult<List<BenefitRequestDTO>>> Get()
        {
            var result = await _mediator.Send(new GetBenefitRequestQuery());
            return Ok(result);
        }

        // GET api/<BenefitRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BenefitRequestDetailsDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetBenefitRequestDetailsQuery(id));
            return Ok(result);
        }

        // POST api/<BenefitRequestController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateBenefitRequestCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), response);
        }

        // PUT api/<BenefitRequestController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateBenefitRequestCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
