using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxLiveSql.features.game
{
    public class LiveGameRecord
    {
        public int Id { get; set; }
        public int GAMEID { get; set; }
        public string Home_team_1 { get; set; }
        public string Away_team_2 { get; set; }
        public int Home_Score_1 { get; set; }
        public int Away_Score_2 { get; set; }
        public int Final_Score { get; set; }
        public string Winner { get; set; }
        public bool IsCompleted { get; set; }
    }
}
