using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsCore.ModelData;

namespace TeamsCore.Repositories.Abstract
{
    public interface ITeamRepository
    {
        void CreateTeam(Team team);
        void DeleteTeam(int teamId);
        Team EditTeam(Team team);
        Team SelectTeam(int teamId);
        List<Team> ViewAllTeams();

    }
}
