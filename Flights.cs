using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightManagement.Models
{
    public class Flights
    {
        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public DateTime FlightArrival { get; set; }
        public DateTime FlightDeparture { get; set; }
        public int PassengersCount { get; set; }
        public int CaptainID { get; set; }
    }
}