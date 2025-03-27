//using System.Linq.Expressions;

using NLPC_EPS_server.DAL.Common;
using System.Linq.Expressions;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> Get(int id);
        Task<T?> Get<T>(int id, Expression<Func<TEntity, T>> selector);
        Task<bool> Exist(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<T> GetAll<T>(Expression<Func<TEntity, T>> selector);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> condition);
        //IQueryable<TEntity> Query(string condition);
        IQueryable<T> Query<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector);
    }
}
