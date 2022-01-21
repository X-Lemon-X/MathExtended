using System;

namespace MathExtended.Math_3D
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
