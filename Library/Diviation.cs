using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    public class Diviation
    {
        private double diviation;

        public Diviation(double diviation)
        {
            this.diviation = diviation;
        }

        public Diviation()
        {
            this.diviation = 0.0000000000001;
        }

        public static Diviation CalculateDiviationByTwoOlmostEqualValues(double value, double value1)
        {
            return new Diviation( Math.Abs(value1 - value));
        }

        public double GetDiviation()
        {
            return this.diviation;
        }
        
    }
}
