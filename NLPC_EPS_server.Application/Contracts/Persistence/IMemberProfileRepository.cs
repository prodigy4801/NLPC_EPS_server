using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IMemberProfileRepository : IGenericRepository<MemberProfile>
    {
        Task<bool> Exist(int Id);
        Task<bool> ExistByEmail(string email);
        Task<List<MemberProfile>> GetActive();
        Task<MemberProfile> GetActiveById(int Id);
        Task<bool> DeactivateMember(int Id);
    }
}
