using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Contracts.Persistence
{
    public interface IEditableRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task SaveChanges();
        Task DoInTransaction(Func<IEditableRepository<TEntity>, Task> action);
        Task<T> DoInTransaction<T>(Func<IEditableRepository<TEntity>, Task<T>> action);
    }
}
