using System;
using System.Collections;
using System.Collections.Generic;

namespace TheWorld.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string TripName { get; set; }
        public DateTime Created { get; set; }
        public string UserName { get; set; }
        public ICollection<Stop> Stops { get; set; }

    }
}