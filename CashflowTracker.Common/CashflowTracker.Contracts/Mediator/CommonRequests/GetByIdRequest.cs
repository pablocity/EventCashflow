using CashflowTracker.Contracts.Mediator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Contracts.Mediator.CommonRequests
{
    public class GetByIdRequest<TResponse> : IRequest<TResponse>
    {
        public long Id { get; set; }
    }
}
