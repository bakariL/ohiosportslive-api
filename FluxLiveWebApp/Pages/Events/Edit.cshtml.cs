using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluxLive.Core;
using FluxLIve.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluxLiveWebApp.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly IEventData _eventData;
        private readonly IHtmlHelper _htmlHelper;

       
        public IEnumerable<SelectListItem> EventItems { get; set; }
        [BindProperty]
        public FluxEvent FluxEvent { get; set; }
        public EventTypes EventTypes { get; set; }


        public EditModel(IEventData eventData,
                         IHtmlHelper htmlHelper)
        {
            _eventData = eventData;
            _htmlHelper = htmlHelper;

        }
        public IActionResult OnGet(int? eventId)
        {
            EventItems = _htmlHelper.GetEnumSelectList<EventTypes>();
            if (eventId.HasValue)
            {
                FluxEvent = _eventData.GetFluxEventById(eventId.Value);
            }
            else
            {
                FluxEvent = new FluxEvent();
            }
            if(FluxEvent == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                EventItems = _htmlHelper.GetEnumSelectList<EventTypes>();
                return Page();
            }
            if(FluxEvent.EventId > 0)
            {
                _eventData.Update(FluxEvent);
            }
            else
            {
                _eventData.Add(FluxEvent);                                                                                               
            }
            _eventData.Commit();
            return RedirectToPage("./Detail", new { eventId = FluxEvent.EventId });

        }
    }
}
