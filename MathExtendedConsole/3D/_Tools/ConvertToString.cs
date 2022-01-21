
namespace MathExtended
{
    public class MEConvertToString
    {
        public static string FromPoint(Point point)
        {
            return "(" + point.GetX() + ";" + point.GetY() + ";" + point.GetZ() + ")";
        }

        public static string FromVector(Vector vector)
        {
            return "[" + vector.GetX() + ";" + vector.GetY() + ";" + vector.GetZ() + "]";
        }
    }
}
