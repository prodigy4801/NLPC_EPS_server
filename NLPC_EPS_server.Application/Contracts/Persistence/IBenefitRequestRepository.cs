using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IBenefitRequestRepository : IGenericRepository<BenefitRequest>
    {
        Task<bool> Exist(int Id);
    }
}
