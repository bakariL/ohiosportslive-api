using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlayersCore.ModelData;
using PlayersCore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxApi.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        //edit player
        [HttpPost("edit/{obj}")]
        //[HttpGet("Edit")]
        public Players EditPlayer([FromBody]Players players)
        {
            //Players fakePlayer = new Players();
            //fakePlayer.FIRST_NAME = "bk jr";
            //fakePlayer.LAST_NAME = "bakari";
            //fakePlayer.IG_NAME = "@bakari";
            //fakePlayer.CITY = "cleveland";
            //fakePlayer.STATE = "ohio";
            //fakePlayer.SCHOOL = "shaker";
            //fakePlayer.TEAMID = 3;
            //fakePlayer.SPORT = "basketball";
            //fakePlayer.Id = 2;
            var editedPlayer = _playerService.EditPlayer(players);
            return editedPlayer;
        }



        //View single player
        [HttpGet("view/{id}")]
        public Players ViewPlayer(int playerId)
        {
            var player = _playerService.GetPlayer(playerId);
            return player;
        }


        //view all players
        [HttpGet("view")]
        public List<Players> ViewAllPlayers()
        {
            var listOfPlayers = _playerService.ViewAllPlayers();
            return listOfPlayers;
        }


        

        //create new player
        [HttpPost("add/{obj}")]
        public IActionResult AddPlayer(Players player)
        {
            Players fakePlayer = new Players();
            fakePlayer.FirstName = "bakari";
            fakePlayer.LastName = "bakari";
            fakePlayer.IgName = "@bakari";
            fakePlayer.City = "cleveland";
            fakePlayer.State = "ohio";
            fakePlayer.School = "shaker";
            fakePlayer.TeamId = 3;
            fakePlayer.Sport = "basketball";
            _playerService.AddPlayer(fakePlayer);
            return Ok();
        }


        //delete player
        [HttpPost("remove/{id}")]
        public IActionResult EditPlayer(int playerId)
        {
             _playerService.DeletePlayer(playerId);
            return Ok();
        }



    }
}
