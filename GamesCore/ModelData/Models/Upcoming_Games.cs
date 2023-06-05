using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCore.ModelData
{
    public class Upcoming_Games 
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public string Location { get; set; }
        public DateTime DateOfGame { get; set; }
        public Guid Status { get; set; }
        public string ImgPath { get; set; }
        public Guid GameAssignmentId { get; set; }
    }
}
