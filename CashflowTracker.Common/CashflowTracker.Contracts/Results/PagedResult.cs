using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Contracts.Results
{
    public class PagedResult<TEntity>
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public long TotalCount { get; private set; }
        public ICollection<TEntity> Collection { get; private set; }

        public PagedResult(int page, int pageSize, long totalCount, ICollection<TEntity> collection)
        {
            this.Page = page;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.Collection = collection;
        }
    }
}
