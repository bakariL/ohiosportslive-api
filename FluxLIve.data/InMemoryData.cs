using FluxLive.Core;
using System.Collections.Generic;
using System.Linq;

namespace FluxLIve.data
{
    public class InMemoryData : IEventData
    {
         private readonly List<FluxEvent> fluxEvents;
        //public InMemoryData()
        //{
        //    fluxEvents = new List<FluxEvent>
        //    {
        //        new FluxEvent { EventId = 1,Name = "SHowdown at Lake",  Description = "taking on the best team" ,EventTypes = EventTypes.Basketball},
        //        new FluxEvent { EventId = 2, Name = "LEL Finals", Description = "close one", EventTypes = EventTypes.Baseball }
        //    };

        //}

        public int Commit()
        {
            return 0;
        }

        public FluxEvent Add(FluxEvent fluxEvent)
        {
            fluxEvents.Add(fluxEvent);
            fluxEvent.EventId = fluxEvents.Max(e => e.EventId) + 1;
            return fluxEvent;
        }

        public FluxEvent Delete(int eventId)
        {
            var evt = fluxEvents.FirstOrDefault(e => e.EventId == eventId);
            if(evt != null)
            {
                fluxEvents.Remove(evt);
            }
            return evt;

        }

        public int GetCountOfEvents()
        {
            return fluxEvents.Count();
        }

        public FluxEvent GetFluxEventById(int eventId)
        {
            return fluxEvents.SingleOrDefault(e => e.EventId == eventId);
        }

        public IEnumerable<FluxEvent> GetFluxEventByName(string name)
        {
            return from e in fluxEvents
                   where string.IsNullOrEmpty(name) || e.Name.StartsWith(name)
                   orderby e.Name
                   select e;
        }

        public FluxEvent Update(FluxEvent fluxEvent)
        {
            var fluxevent = fluxEvents.SingleOrDefault(e => e.EventId == fluxEvent.EventId);
            if (fluxevent != null)
            {
                fluxevent.Name = fluxEvent.Name;
                fluxevent.Description = fluxEvent.Description;
            }
            return fluxevent;
        }

        

      
    }
}
