using System;

namespace GamesCore.ModelData
{
    public class AllGames
    {
        public Guid Id { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public string Location { get; set; }
        public DateTime DateOfGame { get; set; }
        public Guid Status { get; set; }
        public bool IsComplete { get; set; }
        public string ImgPath { get; set; }
        public Guid ScoreId { get; set; }

    }
}
