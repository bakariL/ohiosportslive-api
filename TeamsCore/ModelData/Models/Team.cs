using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsCore.ModelData
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName    { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string HeadCoachName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string ConferenceName { get; set; }
        public int ConferenceRanking { get; set; }
        public int StateRanking { get; set; }
        public int AreaRanking { get; set; }
        public string UpcomingGame { get; set; }
        public string IgName { get; set; }
        public string TwitterName { get; set; }
        public string LogoPath { get; set; }
        public bool InGame { get; set; }
        public bool SeasonPass { get; set; }
        public bool PayPerGame { get; set; }
    }
}
