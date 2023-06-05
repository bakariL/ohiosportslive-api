using GamesCore.ModelData;
using GamesCore.ModelData.Models;
using System;
using System.Collections.Generic;

namespace GameCore.Repositories.Abstract
{
    public interface IGameRepository
    {
        void CreateUpcomingGame(UpcomingGames upcomingGame);
        void DeleteUpcomingGame(int upcomingGameId);
        UpcomingGames EditUpcomingGame(UpcomingGames upcomingGame);
        Games ViewUpcomingGame(int upcomingGameId);
        List<UpcomingGamesData> ViewAllUpcomingGames();
        List<PreviousGamesData> ViewPreviousGamesData();
        List<AllGames> ViewAllGames();
        Games MakeGameClassic(int gameId);
        Games GameIsCompleted(int gameId);
        LiveGames WatchNow(int gameId);
        GameData AcceptGame(Guid upcomingGameId, bool isAccepted);
        List<PreviousGames> ViewPreviousGames();
        List<TodaysGames> ViewTodaysGames();
    }
}

