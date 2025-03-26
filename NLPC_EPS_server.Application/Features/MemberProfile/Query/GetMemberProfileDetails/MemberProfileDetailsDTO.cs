using NLPC_EPS_server.Application.Features.Country.Query.GetAllCountry;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Query.GetMemberProfileDetails
{
    public class MemberProfileDetailsDTO
    {
        public Guid Id { get; set; }
        public EmployeeProfileDTO EmployeeProfile { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public bool ActiveStatus { get; set; }
        public CountryDTO Country { get; set; }
        //public StateDTO State { get; set; }
    }
}
