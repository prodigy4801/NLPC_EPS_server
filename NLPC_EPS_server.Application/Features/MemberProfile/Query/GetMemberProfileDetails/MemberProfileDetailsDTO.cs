using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Query.GetMemberProfileDetails
{
    public class MemberProfileDetailsDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public bool ActiveStatus { get; set; }
    }
}
