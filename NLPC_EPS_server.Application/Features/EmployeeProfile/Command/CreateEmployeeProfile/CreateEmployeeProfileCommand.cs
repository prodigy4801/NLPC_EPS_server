using MediatR;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Command.CreateEmployeeProfile
{
    public class CreateEmployeeProfileCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
    }
}
