using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLPC_EPS_server.Application.Contracts.Identity;
using NLPC_EPS_server.Application.Models.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NLPC_EPS_server.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            this._authenticationService = authenticationService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }


        [Authorize]
        [HttpPut("activate/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> ConfirmEmployeeAccount(string email)
        {
            return Ok(await _authenticationService.ConfirmEmployeeEmail(email));
        }
    }
}
