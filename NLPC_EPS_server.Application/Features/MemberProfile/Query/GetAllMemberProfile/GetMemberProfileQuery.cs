using MediatR;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile
{
    public record GetMemberProfileQuery : IRequest<List<MemberProfileDTO>>;
}
