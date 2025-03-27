using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;
using NLPC_EPS_server.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Persistence.Repositories
{
    public class EmployeeProfileRepository : GenericRepository<EmployeeProfile>, IEmployeeProfileRepository
    {
        public EmployeeProfileRepository(EPSDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> Exist(int Id)
        {
            return await _context.EmployeeProfiles.AnyAsync(x => x.Id == Id);
        }

        public async Task<bool> ExistByEmail(string email)
        {
            return await _context.EmployeeProfiles.AnyAsync(x => x.Email == email);
        }
    }
}
