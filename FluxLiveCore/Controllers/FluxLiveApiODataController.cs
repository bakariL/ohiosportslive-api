using FluxLiveCore.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxApiData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluxLiveApiODataController : ControllerBase
    {
        private readonly FluxApiDataDbContext _fluxApiDataDbContext;

        public FluxLiveApiODataController(FluxApiDataDbContext fluxApiDataDbContext)
        {
            _fluxApiDataDbContext = fluxApiDataDbContext;
        }
        [HttpGet]
        [Route("all-upcoming-games")]
        public IActionResult GetAllUpcomingGames()
        {
            return Ok(_fluxApiDataDbContext.Upcoming_Games.AsQueryable());
        }
    }
}
