using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;
using NLPC_EPS_server.Persistence.Repository;

namespace NLPC_EPS_server.Persistence.Repositories
{
    public class MemberContributionRepository : GenericRepository<MemberContribution>, IMemberContributionRepository
    {
        public MemberContributionRepository(EPSDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsContributionExistByMonth(int month, int memberProfileId)
        {
            return await _context.MemberContributions.AnyAsync(x => x.MemberProfileId == memberProfileId && x.ContributionTypeId == 1 && x.DateCreated!.Value.Month == month);
        }
    }
}
