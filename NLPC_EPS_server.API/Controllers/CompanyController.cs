using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Features.Company.Command.CreateCompany;
using NLPC_EPS_server.Application.Features.Company.Command.UpdateCompany;
using NLPC_EPS_server.Application.Features.Company.Query.GetAllCompany;
using NLPC_EPS_server.Application.Features.Company.Query.GetCompanyDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult<List<CompanyDTO>>> Get()
        {
            var result = await _mediator.Send(new GetCompanyQuery());
            return Ok(result);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetailsDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetCompanyDetailsQuery(id));
            return Ok(result);
        }

        // POST api/<CompanyController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCompanyCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), response);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateCompanyCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
