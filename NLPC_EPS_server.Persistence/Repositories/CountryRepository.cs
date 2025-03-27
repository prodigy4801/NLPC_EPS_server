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
    public class CountryRepository : ICountryRepository
    {
        public EPSDatabaseContext _context { get; protected set; }
        public CountryRepository(EPSDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(int id)
        {
            return await _context.Countries.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistByName(string name)
        {
            return await _context.Countries.AnyAsync(x => x.Name == name);
        }

        public async Task<Country> GetByIDAsync(int id)
        {
            return await _context.Set<Country>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IReadOnlyList<Country>> GetAsync()
        {
            return await _context.Set<Country>().AsNoTracking().ToListAsync();
        }
    }
}
