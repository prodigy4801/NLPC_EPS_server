using NLPC_EPS_server.Application.Models.Identity;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.Contracts.Identity
{
    public interface IEmployeeProfileService
    {
        Task<List<EmployeeProfile>> GetEmployees();
        Task<EmployeeProfile> GetEmployee(string employeeId);
        public string EmployeeEmail { get; }
    }
}
