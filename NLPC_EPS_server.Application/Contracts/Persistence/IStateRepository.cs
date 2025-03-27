using NLPC_EPS_server.DAL;
using System.Linq.Expressions;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IStateRepository
    {
        Task<State> Get(Guid id);
        Task<T?> Get<T>(string id, Expression<Func<State, T>> selector);
        Task<bool> Exist(Guid id);
        Task<bool> Exist(string name);
        Task<IReadOnlyList<State>> GetAll();
        IQueryable<T> GetAll<T>(Expression<Func<State, T>> selector);
        Task<IReadOnlyList<State>> Query(string condition);
        IQueryable<T> Query<T>(Expression<Func<State, bool>> condition, Expression<Func<State, T>> selector);
    }
}
