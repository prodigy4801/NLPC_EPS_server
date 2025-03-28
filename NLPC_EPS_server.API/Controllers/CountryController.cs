using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Features.Country.Query.GetAllCountry;
using NLPC_EPS_server.Application.Features.Country.Query.GetCountryDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<CountryController>
        [HttpGet]

        public async Task<ActionResult<List<CountryDTO>>> Get()
        {
            var result = await _mediator.Send(new GetCountryQuery());
            return Ok(result);
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountryDetailsDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetCountryDetailsQuery(id));
            return Ok(result);
        }
    }
}
