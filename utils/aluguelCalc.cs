using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace car_rentals_project.utils
{
    public class aluguelCalc
    {
        
         public static double CalcularDiasvalor(double priceday , 
         double days) =>
            priceday * days;
    }
}