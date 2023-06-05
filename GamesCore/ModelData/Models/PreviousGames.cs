using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCore.ModelData
{
    public class PreviousGames
    {

        public Guid GameId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public Guid HomeTeamId { get; set; } = Guid.Empty;
        public Guid AwayTeamId { get; set; } = Guid.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTimeOffset DateOfGame { get; set; } = DateTimeOffset.Now;
        public string ImgPath { get; set; }
        public Guid ScoreId { get; set; }


    }
}
