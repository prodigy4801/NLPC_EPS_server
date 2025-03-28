using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;
using NLPC_EPS_server.Persistence.Repository;

namespace NLPC_EPS_server.Persistence.Repositories
{
    public class BenefitRequestRepository : GenericRepository<BenefitRequest>, IBenefitRequestRepository
    {
        public BenefitRequestRepository(EPSDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> Exist(int Id)
        {
            return await _context.BenefitRequests.AnyAsync(x => x.Id == Id);
        }
    }
}
