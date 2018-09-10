using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductBookinUI.Models
{
    public class AirProduct
    { 
            public int Id { get; set; }
            public string FlightCompany { get; set; }
            public System.DateTime DepartureDate { get; set; }
            public System.DateTime ArrivalDate { get; set; }
            public string FromPlace { get; set; }
            public string ToPlace { get; set; }
            public int Price { get; set; }
            public Nullable<bool> isBooked { get; set; }
            public Nullable<bool> isSaved { get; set; } 
    }
}