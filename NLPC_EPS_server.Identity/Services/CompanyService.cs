
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Identity;
using NLPC_EPS_server.Application.Models.Identity;
using NLPC_EPS_server.Identity.DbContext;

namespace NLPC_EPS_server.Identity.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly EPSServerIdentityDbContext _context;

        public CompanyService(EPSServerIdentityDbContext context, IHttpContextAccessor contextAccessor)
        {
            this._context = context;
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await _context.Set<Company>().AsNoTracking().ToListAsync();
        }

        public async Task<Company> GetCompany(int companyId)
        {
            return await _context.Set<Company>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == companyId);
        }
    }
}
