using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashflowTracker.Contracts.Commands;
using CashflowTracker.Contracts.Mediator.Interfaces;
using CashflowTracker.Contracts.Queries;
using CashflowTracker.Handlers.Events.Commands;
using CashflowTracker.Handlers.Events.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CashflowTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IMediator mediator;

        public EventController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetEvents([FromQuery]Query<EventSearchCriteria> query)
        {
            var result = await mediator.Get(new GetAllEventsRequest() { Query = query });

            var actionResult = result.Errors.Any() ? StatusCode(400, result.Errors) : StatusCode(200, result.Result);

            return actionResult;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(long id)
        {
            var result = await mediator.Get(new GetEventByIdRequest() { Id = id });

            var actionResult = result.Errors.Any() ? StatusCode(400, result.Errors) : StatusCode(200, result.Result);

            return actionResult;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateEvent([FromBody]EventCreateCommand command)
        {
            var result = await mediator.Get(new CreateEventRequest() { Command = command });

            var actionResult = result.Errors.Any() ? StatusCode(400, result.Errors) : StatusCode(200, result.Result);

            return actionResult;
        }
    }
}