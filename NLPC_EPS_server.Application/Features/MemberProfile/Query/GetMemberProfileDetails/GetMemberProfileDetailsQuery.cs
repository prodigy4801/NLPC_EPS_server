using MediatR;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Query.GetMemberProfileDetails
{
    public record GetMemberProfileDetailsQuery(int Id) : IRequest<MemberProfileDetailsDTO>;
}
