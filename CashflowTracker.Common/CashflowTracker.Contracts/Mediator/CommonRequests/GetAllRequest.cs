using CashflowTracker.Contracts.Mediator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Contracts.Mediator.CommonRequests
{
    public class GetAllRequest<TResponse, TQuery> : IRequest<TResponse>
    {
        public TQuery Query { get; set; }
    }
}
