using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;

namespace NLPC_EPS_server.Persistence.Repositories
{
    public class ContributionTypeRepository : IContributionTypeRepository
    {
        public EPSDatabaseContext _context { get; protected set; }
        public ContributionTypeRepository(EPSDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(int id)
        {
            return await _context.ContributionTypes.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistByName(string type)
        {
            return await _context.ContributionTypes.AnyAsync(x => x.Type == type);
        }

        public async Task<ContributionType> GetByIDAsync(int id)
        {
            return await _context.Set<ContributionType>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IReadOnlyList<ContributionType>> GetAsync()
        {
            return await _context.Set<ContributionType>().AsNoTracking().ToListAsync();
        }
    }
}
