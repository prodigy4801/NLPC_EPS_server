using MediatR;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Command.UpdateEmployeeProfile
{
    public class UpdateEmployeeProfileCommand : IRequest<Unit>
    {
        public int CompanyId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
