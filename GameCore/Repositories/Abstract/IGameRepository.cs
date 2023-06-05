using GameCore.ModelData;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Repositories.Abstract
{
    public interface IGameRepository
    {
        void CreateUpcomingGame(UpcomingGames upcomingGame);
        void DeleteUpcomingGame(int upcomingGameId);
        UpcomingGames EditUpcomingGame(UpcomingGames upcomingGame);
        UpcomingGames ViewUpcomningGame(int upcomingGameId);
        List<UpcomingGames> ViewAllUpcomingGames();
        Games MakeGameClassic(int gameId);
        Games GameIsCompleted(int gameId);
        LiveGames WatchNow(int gameId);
    }
}

