using NLPC_EPS_server.Application.Features.ContributionType.Query.GetAllContributionType;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
//using NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace NLPC_EPS_server.Application.Features.MemberContribution.Query.GetMemberContributionDetails
{
    public class MemberContributionDetailsDTO
    {
        public int Id { get; set; }
        //public MemberProfileDTO MemberProfile { get; set; }
        public EmployeeProfileDTO EmployeeProfile { get; set; }
        public ContributionTypeDTO ContributionType { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ContributionDate { get; set; }

        
    }
}
