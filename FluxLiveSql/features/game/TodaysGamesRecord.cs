using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxLiveSql.features.game
{
    public class TodaysGamesRecord
    {
        public int GameId { get; set; }
        public string Home_team_1 { get; set; }
        public string Away_team_2 { get; set; }
        //public int TEAM_1_ID { get; set; }
        //public int TEAM_2_ID { get; set; }
        public string LOCATION { get; set; }
        public string IMG_PATH { get; set; }
        //public DateTime Date_of_Game { get; set; }
        //public bool IsCompleted { get; set; }
        //public bool InProgress { get; set; }
    }
}
