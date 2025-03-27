﻿using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IMemberProfileRepository : IGenericRepository<MemberProfile>, IEditableRepository<MemberProfile>
    {
    }
}
