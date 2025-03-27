using NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetAllBenefitProcess;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
using NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest
{
    public class BenefitRequestDTO
    {
        public int Id { get; set; }
        public MemberProfileDTO MemberProfile { get; set; }
        public EmployeeProfileDTO EmployeeProfile { get; set; }
        public BenefitProcessDTO BenefitProcess { get; set; }
        public string RequestDescription { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
    }
}
