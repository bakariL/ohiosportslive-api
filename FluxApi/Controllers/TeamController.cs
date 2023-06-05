using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsCore.ModelData;
using TeamsCore.Services.Abstract;

namespace FluxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("FluxCorsPolicy")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }


        public IActionResult Index()
        {
            return Ok();
        }



        [HttpPost("edit/")]
        public Team Editteam([FromBody]Team Team)
        {

            var editedteam = _teamService.EditTeam(Team);
            return editedteam;
        }



        //View single team
        [HttpGet("view/{id}")]
        public Team Viewteam(int teamId)
        {
            var team = _teamService.SelectTeam(teamId);
            return team;
        }


        //view all Team
        [HttpGet("view")]
        public List<Team> ViewAllTeam()
        {
            var listOfTeam = _teamService.ViewAllTeams();
            return listOfTeam;
        }


        

        //create new team
        [HttpPost("add/")]
        public IActionResult Addteam([FromBody]Team team)
        {
            _teamService.CreateTeam(team);
            return Ok();
        }


        //delete team
        [HttpPost("remove/{id}")]
        public IActionResult Editteam(int teamId)
        {
            _teamService.DeleteTeam(teamId);
            return Ok();
        }

    }
}
