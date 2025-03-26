using NLPC_EPS_server.Application.Features.Company.Query.GetAllCompany;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetEmployeeProfileDetails
{
    public class EmployeeProfileDetailsDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public bool DeleteStatus { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
