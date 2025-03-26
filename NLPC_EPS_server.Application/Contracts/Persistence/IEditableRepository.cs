namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IEditableRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task SaveChanges();
        //Task DoInTransaction(Func<IEditableRepository<TEntity>, Task> action);
        //Task<T> DoInTransaction<T>(Func<IEditableRepository<TEntity>, Task<T>> action);
    }
}
