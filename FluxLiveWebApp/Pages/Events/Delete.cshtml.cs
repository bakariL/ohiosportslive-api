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
    public class DeleteModel : PageModel
    {
        private readonly IEventData _eventData;
        public FluxEvent FluxEvent { get; set; } 
        public DeleteModel(IEventData eventData)
        {
            _eventData = eventData;
        }
        public async Task<IActionResult> OnGet(int eventId)
        {
            FluxEvent = _eventData.GetFluxEventById(eventId);
            if (FluxEvent == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int eventId)
        {
            var evt = _eventData.Delete(eventId);
            _eventData.Commit();

            if(evt == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{evt.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}
