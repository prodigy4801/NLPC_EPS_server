using MediatR;

namespace NLPC_EPS_server.Application.Features.ContributionType.Query.GetAllContributionType
{
    public record GetContributionTypeQuery : IRequest<List<ContributionTypeDTO>>;
}
