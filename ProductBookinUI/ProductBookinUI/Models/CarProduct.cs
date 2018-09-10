using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductBookinUI.Models
{
    public class CarProduct
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string CarNumber { get; set; }
        public int Price { get; set; }
        public Nullable<bool> isBooked { get; set; }
        public Nullable<bool> isSaved { get; set; }
    }
}