using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;

namespace NLPC_EPS_server.Persistence.Repositories
{
    public class StateRepository : IStateRepository
    {
        public EPSDatabaseContext _context { get; protected set; }
        public StateRepository(EPSDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(int id)
        {
            return await _context.States.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistByName(string name)
        {
            return await _context.States.AnyAsync(x => x.Name == name);
        }

        public async Task<State> GetByIDAsync(int id)
        {
            return await _context.Set<State>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IReadOnlyList<State>> GetAsync()
        {
            return await _context.Set<State>().AsNoTracking().ToListAsync();
        }
    }
}
