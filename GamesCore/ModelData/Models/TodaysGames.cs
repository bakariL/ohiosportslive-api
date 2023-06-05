using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCore.ModelData.Models
{
    public class TodaysGames
    {
        public Guid GameId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string StartTime { get; set; }
        public string Description { get; set; }
    }
}
