using NLPC_EPS_server.Application.Features.ContributionType.Query.GetAllContributionType;
using NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Query.GetAllMemberContribution
{
    public class MemberContributionDTO
    {
        public int Id { get; set; }
        public MemberProfileDTO MemberProfile { get; set; }
        public ContributionTypeDTO ContributionType { get; set; }
        public decimal Amount { get; set; }

        
    }
}
