using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.ModelData
{
    public class Games
    {
        public int Id { get; set; }
        public string Home_team_1 { get; set; }
        public string Away_team_2 { get; set; }
        public int Home_Score_1 { get; set; }
        public int Away_Score_2 { get; set; }
        public DateTime Date_of_Game { get; set; }
        public int TEAM_1_ID { get; set; }
        public int TEAM_2_ID { get; set; }
        public int LOCATION { get; set; }
        public bool IsClassic { get; set; }
        public bool KeyPlayers { get; set; }
        public bool IsCompleted { get; set; }
    }
}
