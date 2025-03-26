//using System.Linq.Expressions;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Get(int id);
        Task<TEntity?> Get(Guid id);
        //Task<T?> Get<T>(string id, Expression<Func<TEntity, T>> selector);
        //Task<T?> Get<T>(Guid id, Expression<Func<TEntity, T>> selector);
        Task<bool> Exist(string id);
        Task<bool> Exist(int id);
        Task<IReadOnlyList<TEntity>> GetAll();
        //IQueryable<T> GetAll<T>(Expression<Func<TEntity, T>> selector);
        //IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> condition);
        Task<IReadOnlyList<TEntity>> Query(string condition);
        //IQueryable<T> Query<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector);
    }
}
