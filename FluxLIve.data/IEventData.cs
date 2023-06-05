using FluxLive.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluxLIve.data
{
    public interface IEventData
        {
        IEnumerable<FluxEvent> GetFluxEventByName(string name);
        FluxEvent GetFluxEventById(int eventId);
        FluxEvent Update(FluxEvent fluxEvent);
        FluxEvent Add(FluxEvent fluxEvent);
        FluxEvent Delete(int eventId);
        int Commit();
        int GetCountOfEvents();
    }
}
