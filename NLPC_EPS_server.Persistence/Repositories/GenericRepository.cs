using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL.Common;
using NLPC_EPS_server.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Persistence.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public EPSDatabaseContext _context { get; protected set; }

        public GenericRepository(EPSDatabaseContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> Get(int id)
        {
            var set = GetAll();
            return await set.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T?> Get<T>(int id, Expression<Func<TEntity, T>> selector)
        {
            return await Query(ent => ent.Id == id).Select(selector).SingleOrDefaultAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var set = GetAll();
            return await set.AnyAsync(x => x.Id == id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<T> GetAll<T>(Expression<Func<TEntity, T>> selector)
        {
            return GetAll().Select(selector);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> condition)
        {
            return GetAll().Where(condition);
        }

        //public IQueryable<TEntity> Query(int condition)
        //{
        //    return GetAll().Where(condition);
        //}

        public IQueryable<T> Query<T>(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, T>> selector)
        {
            return GetAll().Where(condition).Select(selector);
        }

        public IQueryable<TEntity> Query(string condition)
        {
            throw new NotImplementedException();
        }
    }
}
