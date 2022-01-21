namespace MathExtended.Math_3D
{
    public class Equasions
    {

        public static bool CompareValues(double value1, double value2, Diviation diviation)
        {
            return (value1 >= (value2 - diviation.GetDiviation())) && (value1 <= (value2 + diviation.GetDiviation()));   
        }

    }
}
