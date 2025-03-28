using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NLPC_EPS_server.Application.Contracts.Identity;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Models.Identity;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Identity.Models;

namespace NLPC_EPS_server.Identity.Services
{
    public class EmployeeProfileService : IEmployeeProfileService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public EmployeeProfileService(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        //public string EmployeeId { get => _contextAccessor.HttpContext?.User?.FindFirst("uid"); }
        public string? EmployeeEmail { get => _contextAccessor.HttpContext?.User.FindFirst("email")?.ToString(); }

        public async Task<EmployeeProfile> GetEmployee(string email)
        {
            var employee = await _userManager.FindByEmailAsync(email);
            if (employee == null) throw new BadRequestExceptions("Employee does not exist.");
            return new EmployeeProfile
            {
                Email = employee.Email,
                FullName = employee.FullName,
                CompanyId = employee.CompanyId,
            };
        }

        public async Task<List<EmployeeProfile>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new EmployeeProfile
            {
                Email = q.Email,
                FullName = q.FullName,
                CompanyId = q.CompanyId,
            }).ToList();
        }
    }
}
