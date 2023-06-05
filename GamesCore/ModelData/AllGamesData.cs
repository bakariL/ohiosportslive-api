using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCore.ModelData
{
    public class AllGamesData : AllGames
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
    }
}
