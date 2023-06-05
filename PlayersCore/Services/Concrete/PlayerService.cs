using PlayersCore.ModelData;
using PlayersCore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayersCore.Repositories.Concrete
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayersRepository _playersRepository;
      
        public PlayerService(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }
        public void AddPlayer(Players player)
        {
            _playersRepository.AddPlayer(player);
        }

        public void DeletePlayer(int playerId)
        {
            _playersRepository.DeletePlayer(playerId);
        }

        public Players EditPlayer(Players players)
        {
            var editedPlayer = _playersRepository.EditPlayer(players);
            return editedPlayer;
        }

        public Players GetPlayer(int playerId)
        {
            var player = _playersRepository.GetPlayer(playerId);
            return player;
        }

        public Players SerachForPlayer(string searchText)
        {
            throw new NotImplementedException();
        }

        public List<Players> ViewAllPlayers()
        {
            var listOfPlayers = _playersRepository.ViewAllPlayers();
            return listOfPlayers;
        }
    }
}
