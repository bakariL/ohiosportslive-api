using GameCore.Repositories.Abstract;
using GamesCore.ModelData;
using GamesCore.ModelData.Models;
using GamesCore.Services.Abstract;
using System;
using System.Collections.Generic;

namespace GamesCore.Services.Concrete
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public GameData AcceptGame(Guid upcomingGameId, bool isAccepted)
        {
            return _gameRepository.AcceptGame(upcomingGameId, isAccepted);
        }

        public void CreateUpcomingGame(UpcomingGames upcomingGame)
        {
            _gameRepository.CreateUpcomingGame(upcomingGame);
        }

        public void DeleteUpcomingGame(int upcomingGameId)
        {
            throw new NotImplementedException();
        }

        public Upcoming_Games EditUpcomingGame(UpcomingGames upcomingGame)
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

        public List<AllGames> ViewAllGames()
        {
            return _gameRepository.ViewAllGames();
        }

        public List<UpcomingGamesData> ViewAllUpcomingGames()
        {
            return _gameRepository.ViewAllUpcomingGames();
        }

        public List<PreviousGames> ViewPreviousGames()
        {
            return _gameRepository.ViewPreviousGames();
        }

        public Games ViewUpcomningGame(int upcomingGameId)
        {
            return _gameRepository.ViewUpcomingGame(upcomingGameId);
        }

        public List<TodaysGames> ViewTodaysGames()
        {
            return _gameRepository.ViewTodaysGames();
        }

        public LiveGames WatchNow(int gameId)
        {
            throw new NotImplementedException();
        }

    }
}
