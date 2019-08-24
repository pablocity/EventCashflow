using CashflowTracker.Contracts.Commands;
using CashflowTracker.Contracts.Dtos;
using CashflowTracker.Contracts.Mediator.Interfaces;
using CashflowTracker.Contracts.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Handlers.Events.Commands
{
    public class CreateEventRequest : IRequest<Response<EventDto>>
    {
        public EventCreateCommand Command { get; set; }
    }
}
