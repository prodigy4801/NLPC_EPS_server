using MediatR;

namespace NLPC_EPS_server.Application.Features.Company.Query.GetCompanyDetails
{
    public record GetCompanyDetailsQuery(int Id) : IRequest<CompanyDetailsDTO>;
}
