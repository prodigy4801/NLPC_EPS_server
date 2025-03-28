using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetAllBenefitProcess;
using NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetBenefitProcessDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    /// <summary>
    /// Class to implement the Member Control Business logic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BenefitProcessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BenefitProcessController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<BenefitProcessController>
        [HttpGet]
        
        public async Task<ActionResult<List<BenefitProcessDTO>>> Get()
        {
            var result = await _mediator.Send(new GetBenefitProcessQuery());
            return Ok(result);
        }

        // GET api/<BenefitProcessController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BenefitProcessDetailsDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetBenefitProcessDetailsQuery(id));
            return Ok(result);
        }
    }
}
