using NLPC_EPS_server.DAL;
using System.Linq.Expressions;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IStateRepository
    {
        Task<State> GetByIDAsync(int id);
        Task<bool> Exist(int id);
        Task<bool> ExistByName(string name);
        Task<IReadOnlyList<State>> GetAsync();
    }
}
