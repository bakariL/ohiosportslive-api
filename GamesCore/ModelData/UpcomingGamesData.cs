using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCore.ModelData
{
    public class UpcomingGamesData
    {
        public Guid GameId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Location { get; set; }
       // public DateTimeOffset DateOfGame { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
    }
}
