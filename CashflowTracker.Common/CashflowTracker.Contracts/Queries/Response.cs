using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Contracts.Queries
{
    public class Response<TEntity>
    {
        public TEntity Result { get; set; }
        public Dictionary<long, string> Errors { get; set; } = new Dictionary<long, string>();
    }
}
