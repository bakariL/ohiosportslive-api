using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsCore.ModelData;
using TeamsCore.Repositories.Abstract;
using TeamsCore.Services.Abstract;

namespace TeamsCore.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public void CreateTeam(Team team)
        {
            _teamRepository.CreateTeam(team);
        }

        public void DeleteTeam(int teamId)
        {
            _teamRepository.DeleteTeam(teamId);
        }

        public Team EditTeam(Team team)
        {
            return _teamRepository.EditTeam(team);
        }

        public Team SelectTeam(int teamId)
        {
            return _teamRepository.SelectTeam(teamId);
        }

        public List<Team> ViewAllTeams()
        {
            throw new NotImplementedException();
        }
    }
}
