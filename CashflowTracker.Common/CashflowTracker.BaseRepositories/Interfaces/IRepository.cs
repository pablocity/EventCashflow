using CashflowTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.BaseRepositories.Interfaces
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>, IWriteOnlyRepository<TEntity>
        where TEntity : Entity
    {
    }
}
