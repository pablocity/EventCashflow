using CashflowTracker.BaseRepositories.Implementations;
using CashflowTracker.Data;
using CashflowTracker.Models;
using CashflowTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashflowTracker.Repositories.Implementations
{
    public class EventRepository : Repository<Event, CashflowTrackerContext, long>, IEventRepository
    {
        public EventRepository(CashflowTrackerContext context)
            : base(context, entity => entity.Id)
        {

        }
    }
}
