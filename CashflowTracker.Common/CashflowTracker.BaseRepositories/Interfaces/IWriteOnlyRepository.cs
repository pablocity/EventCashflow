using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.BaseRepositories.Interfaces
{
    public interface IWriteOnlyRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(long id);
        void Commit();
        Task CommitAsync();
    }
}
