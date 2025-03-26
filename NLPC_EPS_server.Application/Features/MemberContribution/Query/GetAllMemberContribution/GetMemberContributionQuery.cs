using MediatR;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Query.GetAllMemberContribution
{
    public record GetMemberContributionQuery : IRequest<List<MemberContributionDTO>>;
}
