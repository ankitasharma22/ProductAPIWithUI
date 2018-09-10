using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductBookinUsingEntity.Controllers
{

    public class CarStrategy : IStrategy
    {
        public int FareCalculation(int inputPrice)
        {  
            return Convert.ToInt32(inputPrice * 0.8);
        }
    }
}