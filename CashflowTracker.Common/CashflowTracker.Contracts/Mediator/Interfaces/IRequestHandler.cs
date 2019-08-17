using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.Contracts.Mediator.Interfaces
{
    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
