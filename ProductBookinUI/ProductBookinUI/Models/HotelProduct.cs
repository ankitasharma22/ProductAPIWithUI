using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductBookinUI.Models
{
    public class HotelProduct
    {
        public int Id { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string LandMark { get; set; }
        public int Price { get; set; }
        public Nullable<bool> isBooked { get; set; }
        public Nullable<bool> isSaved { get; set; }
    }
}