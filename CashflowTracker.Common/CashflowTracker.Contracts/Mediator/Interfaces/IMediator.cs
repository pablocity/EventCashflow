using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.Contracts.Mediator.Interfaces
{
    public interface IMediator
    {
        Assembly HandlersAssembly { get; set; }
        Task<TResponse> Get<TResponse>(IRequest<TResponse> request);
    }
}
