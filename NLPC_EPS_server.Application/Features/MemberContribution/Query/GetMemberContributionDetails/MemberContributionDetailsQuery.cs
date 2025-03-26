using MediatR;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Query.GetMemberContributionDetails
{
    public record GetMemberContributionDetailsQuery(int Id) : IRequest<MemberContributionDetailsDTO>;
}
