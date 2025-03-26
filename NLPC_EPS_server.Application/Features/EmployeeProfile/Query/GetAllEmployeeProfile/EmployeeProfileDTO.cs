namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile
{
    public class EmployeeProfileDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
    }
}
