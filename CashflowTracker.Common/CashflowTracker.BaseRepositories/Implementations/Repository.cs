using CashflowTracker.BaseRepositories.Interfaces;
using CashflowTracker.Contracts.Results;
using CashflowTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.BaseRepositories.Implementations
{
    public class Repository<TEntity, TContext, TKey> : IRepository<TEntity>
        where TEntity : Entity, new()
        where TContext : DbContext
    {
        protected TContext Context { get; }
        protected DbSet<TEntity> DbSet { get; }
        protected Expression<Func<TEntity, TKey>> DefaultKey { get; }

        public Repository(TContext context, Expression<Func<TEntity, TKey>> defaultKey)
        {
            this.Context = context;
            this.DbSet = Context.Set<TEntity>();
            this.DefaultKey = defaultKey;
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await DbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<PagedResult<TEntity>> GetPageAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize)
        {
            var entities = DbSet.Where(predicate);
            var totalCount = await DbSet.LongCountAsync();

            var pageCollection = await entities
                .Skip(page > 0 ? pageSize * (page - 1) : 0)
                .Take(pageSize > 0 ? pageSize : 5)
                .AsNoTracking()
                .ToListAsync();

            return new PagedResult<TEntity>(page, pageSize, totalCount, pageCollection);
        }

        public Task<PagedResult<TEntity>> GetOrderedPageAsync(Expression<Func<TEntity, bool>> predicate, string sortingExpression, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            AttachIfDetached(entity);
            SetModified(entity);
        }

        public void Delete(long id)
        {
            var entityToDelete = new TEntity() { Id = id };
            AttachIfDetached(entityToDelete);
            SetDeleted(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            AttachIfDetached(entity);
            SetDeleted(entity);
        }

        protected void SetDeleted(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        protected void SetModified(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        protected void AttachIfDetached(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Attach(entity);
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
