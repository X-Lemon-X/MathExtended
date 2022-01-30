using System;

namespace MathExtended.Math_3D
{
    public class Equasions
    {

        public static bool CompareValues(double value1, double value2, Diviation diviation)
        {
            return Math.Abs(value2 - value1) <= diviation.GetDiviation();   
        }

    }
}
