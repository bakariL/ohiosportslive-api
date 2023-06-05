using FluxLive.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace FluxLIve.data
{
    public class SqlEventData : IEventData
    {
        private readonly FluxEventDbContext _dbContext;
        public SqlEventData(FluxEventDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public FluxEvent Add(FluxEvent fluxEvent)
        {
            _dbContext.Add(fluxEvent);
            return fluxEvent;
        }

        public FluxEvent Delete(int eventId)
        {
            var evt = GetFluxEventById(eventId);
            if (evt != null)
            {
                _dbContext.FluxEvents.Remove(evt);
            }

            return evt;
        }

        public int GetCountOfEvents()
        {
            return _dbContext.FluxEvents.Count();
        }

        public FluxEvent GetFluxEventById(int eventId)
        {
            return _dbContext.FluxEvents.Find(eventId);
        }

        public IEnumerable<FluxEvent> GetFluxEventByName(string name)
        {
            var query = from e in _dbContext.FluxEvents
                        where e.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby e.Name
                        select e;

            return query;
        }

        public FluxEvent Update(FluxEvent fluxEvent)
        {
            var entity = _dbContext.Attach(fluxEvent);
            entity.State = EntityState.Modified;
            return fluxEvent;
        }
    }
}
