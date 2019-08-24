using AutoMapper;
using CashflowTracker.Contracts.Commands;
using CashflowTracker.Contracts.Dtos;
using CashflowTracker.Contracts.Results;
using CashflowTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Handlers.MapperProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventCreateCommand, Event>();
            CreateMap<Event, EventDto>();

            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));
        }
    }
}
