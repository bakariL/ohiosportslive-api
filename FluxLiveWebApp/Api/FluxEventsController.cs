using FluxLive.Core;
using FluxLIve.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxLiveWebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluxEventsController : ControllerBase
    {
        private readonly FluxEventDbContext _fluxEventDbContext;

        public FluxEventsController(FluxEventDbContext fluxEventDbContext)
        {
            _fluxEventDbContext = fluxEventDbContext;
        }


        [HttpGet]
        public IEnumerable<FluxEvent> GetFluxEvents()
        {
            return _fluxEventDbContext.FluxEvents;
        }


        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetFluxEvent([FromRoute]int eventId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evnt = await _fluxEventDbContext.FluxEvents.FindAsync(eventId);

            if(evnt == null)
            {
                return NotFound();
            }

            return Ok(evnt);
        }



    }
}
