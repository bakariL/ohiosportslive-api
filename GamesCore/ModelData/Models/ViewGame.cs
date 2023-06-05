using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCore.ModelData
{
    public class ViewGame
    {

        public int GameId { get; set; }
        public string Home_Team_1 { get; set; }
        public string Away_Team_2 { get; set; }
        public string KeyPlayers { get; set; }
        public bool IsAccepted { get; set; }
    }
}
