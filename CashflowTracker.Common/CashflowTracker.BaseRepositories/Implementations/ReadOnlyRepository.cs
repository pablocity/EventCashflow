using CashflowTracker.BaseRepositories.Interfaces;
using CashflowTracker.Contracts.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.BaseRepositories.Implementations
{
    public class ReadOnlyRepository<TEntity, TContext, TKey> : IReadOnlyRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext Context { get; }
        protected DbSet<TEntity> DbSet { get; }
        protected Expression<Func<TEntity, TKey>> DefaultKey { get; }

        public ReadOnlyRepository(TContext context, Expression<Func<TEntity, TKey>> defaultKey)
        {
            this.Context = context;
            this.DbSet = Context.Set<TEntity>();
            this.DefaultKey = defaultKey;
        }

        public Task<ICollection<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<TEntity>> GetOrderedPageAsync(Expression<Predicate<TEntity>> predicate, string sortingExpression, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<TEntity>> GetPageAsync(Expression<Predicate<TEntity>> predicate, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<TEntity>> GetPageAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<TEntity>> GetOrderedPageAsync(Expression<Func<TEntity, bool>> predicate, string sortingExpression, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
