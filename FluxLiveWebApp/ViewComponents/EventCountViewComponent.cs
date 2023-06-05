using FluxLIve.data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxLiveWebApp.ViewComponents
{
    public class EventCountViewComponent : ViewComponent
    {

        private readonly IEventData _eventData1;
        public EventCountViewComponent(IEventData eventData)
        {
            _eventData1 = eventData;
        }

        public IViewComponentResult Invoke()
        {
            var count = _eventData1.GetCountOfEvents();
            return View(count);
        }
    }
}
