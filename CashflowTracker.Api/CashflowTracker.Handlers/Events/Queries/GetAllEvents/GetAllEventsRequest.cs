using CashflowTracker.Contracts.Dtos;
using CashflowTracker.Contracts.Mediator.CommonRequests;
using CashflowTracker.Contracts.Mediator.Interfaces;
using CashflowTracker.Contracts.Queries;
using CashflowTracker.Contracts.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Handlers.Events.Queries
{
    public class GetAllEventsRequest : GetAllRequest<Response<PagedResult<EventDto>>, Query<EventSearchCriteria>>
    {
    }
}
