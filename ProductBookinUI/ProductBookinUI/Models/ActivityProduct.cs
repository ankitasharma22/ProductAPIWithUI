using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductBookinUI.Models
{
    public class ActivityProduct
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public int Price { get; set; }
        public string Place { get; set; }
        public Nullable<bool> isBooked { get; set; }
        public Nullable<bool> isSaved { get; set; }
    }
}
