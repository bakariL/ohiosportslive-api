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
    public class ListModel : PageModel
    {
        private readonly IEventData _eventData;

        public String Message { get; set; }
        public IEnumerable<FluxEvent> EventDatas { get; set; }
       
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IEventData eventData)
        {
            _eventData = eventData;
        }
        public void OnGet()
        {
            Message = "hello world1";
            EventDatas = _eventData.GetFluxEventByName(SearchTerm);
        }


    }
}
