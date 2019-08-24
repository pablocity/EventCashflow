using AutoMapper;
using CashflowTracker.Contracts.Dtos;
using CashflowTracker.Contracts.Mediator.Interfaces;
using CashflowTracker.Contracts.Queries;
using CashflowTracker.Models;
using CashflowTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashflowTracker.Handlers.Events.Commands
{
    public class CreateEventHandler : IRequestHandler<CreateEventRequest, Response<EventDto>>
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;

        public CreateEventHandler(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }
        public async Task<Response<EventDto>> Handle(CreateEventRequest request)
        {
            //TODO validation

            var entity = mapper.Map<Event>(request.Command);

            eventRepository.Create(entity);

            await eventRepository.CommitAsync();

            return new Response<EventDto>() { Result = mapper.Map<EventDto>(entity) };
        }
    }
}
