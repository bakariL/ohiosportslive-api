using GameCore.ModelData;
using GameCore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GameCore.Repositories.Concrete
{
    public class GameRepository : IGameRepository
    {
        public void CreateUpcomingGame(UpcomingGames upcomingGame)
        {
            using SqlConnection con = new SqlConnection(); ; )
        }

        public void DeleteUpcomingGame(int upcomingGameId)
        {
            throw new NotImplementedException();
        }

        public UpcomingGames EditUpcomingGame(UpcomingGames upcomingGame)
        {
            throw new NotImplementedException();
        }

        public Games GameIsCompleted(int gameId)
        {
            throw new NotImplementedException();
        }

        public Games MakeGameClassic(int gameId)
        {
            throw new NotImplementedException();
        }

        public List<UpcomingGames> ViewAllUpcomingGames()
        {
            throw new NotImplementedException();
        }

        public UpcomingGames ViewUpcomningGame(int upcomingGameId)
        {
            throw new NotImplementedException();
        }

        public LiveGames WatchNow(int gameId)
        {
            throw new NotImplementedException();
        }

        List<UpcomingGames> IGameRepository.ViewAllUpcomingGames()
        {
            throw new NotImplementedException();
        }
    }
}
