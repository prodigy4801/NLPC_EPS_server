using MediatR;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetEmployeeProfileDetails
{
    public record GetEmployeeProfileDetailsQuery(int Id) : IRequest<EmployeeProfileDetailsDTO>;
}
