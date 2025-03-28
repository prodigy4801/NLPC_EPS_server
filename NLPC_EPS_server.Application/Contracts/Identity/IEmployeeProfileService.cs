using NLPC_EPS_server.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Contracts.Identity
{
    public interface IEmployeeProfileService
    {
        Task<List<EmployeeProfile>> GetEmployees();
        Task<EmployeeProfile> GetEmployee(string employeeId);
        public string EmployeeEmail { get; }
    }
}
