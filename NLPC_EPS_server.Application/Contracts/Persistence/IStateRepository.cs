using NLPC_EPS_server.DAL;
using System.Linq.Expressions;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IStateRepository
    {
        Task<State> GetByIDAsync(Guid id);
        Task<bool> Exist(Guid id);
        Task<bool> ExistByName(string name);
        Task<IReadOnlyList<State>> GetAsync();
    }
}
