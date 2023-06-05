using GamesCore.ModelData;
using GamesCore.ModelData.Models;
using System;
using System.Collections.Generic;

namespace GamesCore.Services.Abstract
{
    public interface IGameService
    {

        void CreateUpcomingGame(UpcomingGames upcomingGame);
        void DeleteUpcomingGame(int upcomingGameId);
        Upcoming_Games EditUpcomingGame(UpcomingGames upcomingGame);
        Games ViewUpcomningGame(int upcomingGameId);
        List<UpcomingGamesData> ViewAllUpcomingGames();
        List<PreviousGames> ViewPreviousGames();
        List<AllGames> ViewAllGames();
        List<TodaysGames> ViewTodaysGames();
        Games MakeGameClassic(int gameId);
        Games GameIsCompleted(int gameId);
        LiveGames WatchNow(int gameId);
        GameData AcceptGame(Guid upcomingGameId, bool isAccepted);
 
    }
}
