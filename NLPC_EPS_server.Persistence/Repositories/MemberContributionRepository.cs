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
    }
}
