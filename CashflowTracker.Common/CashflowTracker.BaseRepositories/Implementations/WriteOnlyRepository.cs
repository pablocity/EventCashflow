using CashflowTracker.BaseRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.BaseRepositories.Implementations
{
    public class WriteOnlyRepository<TEntity, TContext> : IWriteOnlyRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext Context { get; }
        protected DbSet<TEntity> DbSet { get; }

        public WriteOnlyRepository(TContext context)
        {
            this.Context = context;
            this.DbSet = Context.Set<TEntity>();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        protected void SetDeleted(TEntity entity)
        {
            
        }

        protected void SetModified(TEntity entity)
        {

        }

        protected void AttachIfDetached(TEntity entity)
        {

        }
    }
}
