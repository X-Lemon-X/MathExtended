using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    public class Equasions
    {

        public static bool CompareValues(double value1, double value2, Diviation diviation)
        {
            return (value1 >= (value2 - diviation.GetDiviation())) && (value1 <= (value2 + diviation.GetDiviation()));   
        }

    }
}
