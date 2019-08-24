using CashflowTracker.Contracts.Dtos;
using CashflowTracker.Contracts.Mediator.Interfaces;
using CashflowTracker.Contracts.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.Handlers.Events.Queries
{
    public class GetEventByIdHandler : IRequestHandler<GetEventByIdRequest, Response<EventDto>>
    {
        public async Task<Response<EventDto>> Handle(GetEventByIdRequest request)
        {
            return await Task.Run(() =>
            {
                return new Response<EventDto>() { Result = new EventDto() };
            });
        }
    }
}
