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
    public class BenefitProcessRepository : GenericRepository<BenefitProcess>, IBenefitProcessRepository
    {
        public BenefitProcessRepository(EPSDatabaseContext context) : base(context)
        {
        }
    }
}
