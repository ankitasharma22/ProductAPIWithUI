﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductBookinUsingEntity.Controllers
{
    public class AirStrategy : IStrategy
    {
        public int FareCalculation(int inputPrice)
        {
            return Convert.ToInt32(inputPrice * 0.7);
        }
    }
}