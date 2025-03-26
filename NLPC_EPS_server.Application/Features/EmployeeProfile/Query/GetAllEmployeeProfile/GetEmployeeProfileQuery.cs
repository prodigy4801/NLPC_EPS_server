using MediatR;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile
{
    public record GetEmployeeProfileQuery : IRequest<List<EmployeeProfileDTO>>;
}
