using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCore.ModelData
{
    public class LiveGames
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string Home_team { get; set; }
        public string Away_team { get; set; }
        public int Home_Score { get; set; }
        public int Away_Score { get; set; }
        public int Final_Score { get; set; }
        public string Winner { get; set; }
        public bool IsCompleted { get; set; }
    }
}

