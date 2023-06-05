using System;

namespace GamesCore.ModelData.ResponseModels
{
    public class UpcomingGameResponse
    {
        public Guid GameId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Location { get; set; }
        public DateTimeOffset DateOfGame { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
    }
}
