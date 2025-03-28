using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;

namespace NLPC_EPS_server.Persistence.Repositories
{
    public class BenefitProcessRepository : IBenefitProcessRepository
    {
        public EPSDatabaseContext _context { get; protected set; }
        public BenefitProcessRepository(EPSDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(int id)
        {
            return await _context.BenefitProcesses.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistByName(string processcode)
        {
            return await _context.BenefitProcesses.AnyAsync(x => x.ProcessCode == processcode);
        }

        public async Task<BenefitProcess> GetByIDAsync(int id)
        {
            return await _context.Set<BenefitProcess>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IReadOnlyList<BenefitProcess>> GetAsync()
        {
            return await _context.Set<BenefitProcess>().AsNoTracking().ToListAsync();
        }
    }
}
