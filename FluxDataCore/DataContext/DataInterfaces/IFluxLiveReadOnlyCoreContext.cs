using GamesCore.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxDataCore.DataContext.DataInterfaces
{
    public interface IFluxLiveReadOnlyCoreContext
    {
        IQueryable<UpcomingGames> UpcomingGames { get; }
    }
}
