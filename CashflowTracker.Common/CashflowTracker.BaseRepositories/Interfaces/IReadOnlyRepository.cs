using CashflowTracker.Contracts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.BaseRepositories.Interfaces
{
    public interface IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<PagedResult<TEntity>> GetPageAsync(Expression<Func<TEntity, bool>> predicate, int page, int pageSize);
        Task<PagedResult<TEntity>> GetOrderedPageAsync(Expression<Func<TEntity, bool>> predicate, string sortingExpression, int page, int pageSize);
        Task<TEntity> GetAsync(long id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
