using NLPC_EPS_server.Application.Models.Identity;

namespace NLPC_EPS_server.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthenticationResponse> Login(AuthenticationRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<bool> ConfirmEmployeeEmail(string email);
    }
}
