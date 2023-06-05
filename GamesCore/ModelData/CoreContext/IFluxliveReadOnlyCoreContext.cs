using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCore.ModelData.CoreContext
{
    public interface IFluxLiveReadOnlyCoreContext
    {
        IQueryable<UpcomingGames> UpcomingGames { get; }
    }
}
