using MediatR;
using NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetBenefitProcessDetails;

namespace NLPC_EPS_server.Application.Features.ContributionType.Query.GetContributionTypeDetails
{
    public record GetContributionTypeDetailsQuery(int Id) : IRequest<ContributionTypeDetailsDTO>;
}
