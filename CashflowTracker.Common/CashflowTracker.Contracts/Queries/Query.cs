using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Contracts.Queries
{
    public class Query
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class Query<TSearchCriteria>
    {
        public TSearchCriteria SearchCriteria { get; set; }
    }
}
