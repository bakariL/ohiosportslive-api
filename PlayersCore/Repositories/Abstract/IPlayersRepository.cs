using PlayersCore.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersCore.Repositories.Abstract
{
    public interface IPlayersRepository
    {
        Players GetPlayer(int playerId);
        void AddPlayer(Players player);
        void DeletePlayer(int playerId);
        Players EditPlayer(Players players);
        Players SerachForPlayer(string searchText);
        List<Players> ViewAllPlayers();

    }
}
