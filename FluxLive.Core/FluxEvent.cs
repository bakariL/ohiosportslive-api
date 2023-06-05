using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FluxLive.Core
{
 
    public class FluxEvent
    {
        [Key]
        public int EventId { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }

        public string Description  { get; set; }
        //public string TeamOne { get; set; }
        //public string TeamTwo { get; set; }
        //public DateTime EventDate { get; set; }
        public EventTypes EventTypes { get; set; }
    }
}
