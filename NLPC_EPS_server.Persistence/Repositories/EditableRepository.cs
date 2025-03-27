
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL.Common;
using NLPC_EPS_server.Persistence.DataAccess;
using NLPC_EPS_server.Persistence.Repository;

namespace NLPC_EPS_server.Persistence.Repositories
{
    public abstract class EditableRepository<TEntity> : GenericRepository<TEntity>, IEditableRepository<TEntity> 
        where TEntity : BaseEntity
    {
        protected EditableRepository(EPSDatabaseContext context) : base(context){}

        public async Task DoInTransaction(Func<IEditableRepository<TEntity>, Task> action)
        {
            var txContext = this._context.Database.BeginTransaction();
            try
            {
                await action(this);
                await txContext.CommitAsync();
            }
            catch (Exception ex)
            {
                await txContext.RollbackAsync();

                throw;
            }
        }

        public async Task<T> DoInTransaction<T>(Func<IEditableRepository<TEntity>, Task<T>> action)
        {
            var txContext = this._context.Database.BeginTransaction();
            try
            {
                var result = await action(this);
                await txContext.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await txContext.RollbackAsync();
                throw;
            }
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            var changeTracking = await this._context.Set<TEntity>().AddAsync(entity);
            return changeTracking.Entity;
        }

        public virtual async Task SaveChanges()
        {
            await this._context.SaveChangesAsync();
        }

        public virtual Task<TEntity> Update(TEntity entity)
        {
            var entry = this._context.Entry(entity);
            if (entry?.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                this._context.Attach(entity);
            if (entry == null || entry.State != Microsoft.EntityFrameworkCore.EntityState.Modified)
                return Task.FromResult(this._context.Update(entity).Entity);

            return Task.FromResult(entity);
        }
    }
}
