using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.ModelData
{
    public class LiveGames
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
