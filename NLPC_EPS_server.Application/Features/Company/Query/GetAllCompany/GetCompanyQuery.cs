using MediatR;

namespace NLPC_EPS_server.Application.Features.Company.Query.GetAllCompany
{
    public record GetCompanyQuery : IRequest<List<CompanyDTO>>;
}
