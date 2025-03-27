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
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(EPSDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> Exist(int id)
        {
            return await _context.Companies.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistByName(string name)
        {
            return await _context.Companies.AnyAsync(x => x.Name == name);
        }
    }
}
