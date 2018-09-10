using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBookinUsingEntity.Controllers
{
    interface IStrategy
    {
        int FareCalculation(int inputPrice);
    }
}
