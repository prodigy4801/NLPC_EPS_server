using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile
{
    public class MemberProfileDTO
    {
        public int Id { get; set; }
        public EmployeeProfileDTO EmployeeProfile { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
