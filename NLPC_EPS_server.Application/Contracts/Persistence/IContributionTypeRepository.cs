using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IContributionTypeRepository
    {
        Task<ContributionType> GetByIDAsync(int id);
        Task<bool> Exist(int id);
        Task<bool> ExistByName(string name);
        Task<IReadOnlyList<ContributionType>> GetAsync();
    }
}
