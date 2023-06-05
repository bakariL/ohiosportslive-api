using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluxLive.Core;
using FluxLIve.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FluxLiveWebApp.Pages.Events
{
    public class DetailModel : PageModel
    {
        public FluxEvent FluxEvent {get; set;}
        public IEventData _eventData;
        public DetailModel(IEventData eventData)
        {
            _eventData = eventData;
        }
        public IActionResult OnGet(int eventId)
        {
            FluxEvent = _eventData.GetFluxEventById(eventId);
            if (FluxEvent == null )
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
