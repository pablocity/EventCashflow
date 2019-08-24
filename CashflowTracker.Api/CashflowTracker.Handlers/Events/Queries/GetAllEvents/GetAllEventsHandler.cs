using AutoMapper;
using CashflowTracker.Contracts.Dtos;
using CashflowTracker.Contracts.Mediator.Interfaces;
using CashflowTracker.Contracts.Queries;
using CashflowTracker.Contracts.Results;
using CashflowTracker.Models;
using CashflowTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.Handlers.Events.Queries
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsRequest, Response<PagedResult<EventDto>>>
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;

        public GetAllEventsHandler(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }
        public async Task<Response<PagedResult<EventDto>>> Handle(GetAllEventsRequest request)
        {
            //TODO validation

            //TODO building filtering expression

            var entities = await eventRepository.GetPageAsync((x) => true, request.Query.Page, request.Query.PageSize);

            var dtos = mapper.Map<PagedResult<EventDto>>(entities);

            //TODO proper response
            return new Response<PagedResult<EventDto>>() { Result = dtos };
        }
    }
}
