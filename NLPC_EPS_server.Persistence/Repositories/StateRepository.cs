using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;
using NLPC_EPS_server.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Persistence.Repositories
{
    public class StateRepository : IStateRepository
    {
        public EPSDatabaseContext _context { get; protected set; }
        public StateRepository(EPSDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(Guid id)
        {
            return await _context.States.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistByName(string name)
        {
            return await _context.States.AnyAsync(x => x.Name == name);
        }

        public async Task<State> GetByIDAsync(Guid id)
        {
            return await _context.Set<State>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IReadOnlyList<State>> GetAsync()
        {
            return await _context.Set<State>().AsNoTracking().ToListAsync();
        }
    }
}
