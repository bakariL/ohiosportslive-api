using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCore.ModelData
{
    public class GameData 
    {
        public Guid GameId { get; set; }
        public string Title { get; set; }    
        public string HomeTeam { get; set; }    
        public string GuestTeam { get; set; }    
        public string Location { get; set; }    
        public DateTimeOffset DateAndTime { get; set; }
        public int HomeTeamCurrentScore { get; set; }
        public int AwayTeamCurrentScore { get; set; }
        public int CurrentQuarter { get; set; }
        public string Winner { get; set; }
        public bool IsComplete { get; set; }
        public bool IsAccetped { get; set; }
       
    }
}
