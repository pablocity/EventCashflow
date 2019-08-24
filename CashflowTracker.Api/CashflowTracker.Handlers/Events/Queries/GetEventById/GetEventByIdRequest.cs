using CashflowTracker.Contracts.Dtos;
using CashflowTracker.Contracts.Mediator.Interfaces;
using CashflowTracker.Contracts.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Handlers.Events.Queries
{
    public class GetEventByIdRequest : IRequest<Response<EventDto>>
    {
        public long Id { get; set; }
    }
}
