﻿using NLPC_EPS_server.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IMemberContributionRepository : IGenericRepository<MemberContribution>
    {
        Task<bool> IsContributionExistByMonth(int month, int memberProfileId);
    }
}
