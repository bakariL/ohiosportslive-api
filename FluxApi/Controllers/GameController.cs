using GamesCore.ModelData;
using GamesCore.ModelData.Models;
using GamesCore.Services.Abstract;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet,Route("viewAll")]
        public List<UpcomingGamesData> GetAllGames()
            {
           var res =  _gameService.ViewAllUpcomingGames();
            return res;
        }

        [HttpGet, Route("upcoming")]
        public List<UpcomingGamesData> GetUpcomingGames()
        {
            var res = _gameService.ViewAllUpcomingGames();

            return res;
        }

        [HttpGet, Route("upcomingg")]
        [ProducesDefaultResponseType(typeof(List<UpcomingGamesData>))]
        public async Task<IActionResult> GetUpcomingGamess()
        {
            var res = _gameService.ViewAllUpcomingGames();

            return Ok();
        }

        [HttpGet, Route("today")]
        public List<TodaysGames> GetTodaysGames()
        {
            var res = _gameService.ViewTodaysGames();

            return res;
        }

        [HttpGet, Route("previousGames")]
        public List<PreviousGames> GetPreviousGames()
        {
            var res = _gameService.ViewPreviousGames();

            return res;
        }



        [HttpGet, Route("viewAllYt")]
        public List<string> GetAllYouTubeGames()
        {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyBtsHAH-7I6K_IsuC6qNpJHHiHjNNJjfeM",
                    ApplicationName = this.GetType().ToString()
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = "Sports"; // Replace with your search term.
                searchListRequest.MaxResults = 50;

                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = searchListRequest.Execute();
                List<YouTubeLiveSportsVideos> yt_livesportsvideo_data = new List<YouTubeLiveSportsVideos>();
            
                

                List<string> videonames = new List<string>();
                List<string> videoids = new List<string>();
                List<string> channels = new List<string>();
                List<string> playlists = new List<string>();

                // Add each result to the appropriate list, and then display the lists of
                // matching videos, channels, and playlists.
                foreach (var searchResult in searchListResponse.Items)
                {
                    switch (searchResult.Id.Kind)
                    {
                        case "youtube#video":
                        videonames.Add(String.Format("{0}", searchResult.Snippet.Title, searchResult.Id.VideoId));
                        videoids.Add(String.Format("{1}", searchResult.Snippet.Title, searchResult.Id.VideoId));
                            break;

                        case "youtube#channel":
                            channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                            break;

                        case "youtube#playlist":
                            playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                            break;
                    }
                }

                Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videonames)));
                Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", videoids)));
                Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", channels)));

            return videoids;
        }

        [HttpPost,Route("new-game")]
        public IActionResult CreateGame([FromBody] UpcomingGames game)
        {
            StripeConfiguration.ApiKey = "sk_test_51HmMK1Dkg1t2kwCzSkqjEUoJeExNLwxE4r61bvI2RlhtZRouWdu6pvj1IwXVqW3Ofs4mTPxjxaYGPSIfjEgiKR6W00ErbyYaLd";

            string gameTitle = "";
            gameTitle = game.HomeTeam + "vs. " + game.AwayTeam;

            var options = new ProductCreateOptions
            {
                Name = gameTitle,
                Active = true,
                Description = game.Description,

            };
            var service = new ProductService();
            var prodoct_details = service.Create(options);


            var price_options = new PriceCreateOptions
            {
                UnitAmount = 2000,
                Currency = "usd",
                //Recurring = new PriceRecurringOptions
                //{
                //    Interval = "month",
                //},
                Product = prodoct_details.Id,
            };
            var price_service = new PriceService();
            var price_obj = price_service.Create(price_options);

            UpcomingGames gameData = new UpcomingGames();
            

            _gameService.CreateUpcomingGame(game);
            return Ok();
        }

        [HttpGet, Route("view/{gameId}")]
        public Games GetGame(int gameId)
        {
            var game = new Games();
            game = _gameService.ViewUpcomningGame(gameId);
            return game;
        }

        [HttpPost, Route("view/{gameId}/accept")]
        public GameData AcceptGame([FromBody] GameData game)
        {
            var game_ = new GameData();
            game_ = _gameService.AcceptGame(game.GameId, game.IsAccetped);

            return game_;
        }

        //[HttpGet, Route("view/")]
        //public ViewGame ViewAcceptedGame()
        //{
        //    var viewGame = new ViewGame();

        //    return viewGame;
        //}


    }
}
