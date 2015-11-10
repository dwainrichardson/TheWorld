using System;

namespace TheWorld.Models
{
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public double longitude { get; set; }
        public double latitude { get; set; }
        public DateTime Arrival { get; set; }
        public int Order { get; set; }
    }
}