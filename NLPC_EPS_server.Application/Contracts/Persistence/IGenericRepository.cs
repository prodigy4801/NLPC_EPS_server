//using System.Linq.Expressions;

using NLPC_EPS_server.DAL.Common;
using System.Linq.Expressions;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
