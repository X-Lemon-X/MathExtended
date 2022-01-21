
namespace MathExtended.Math_3D
{
    public class PointEquasions
    {
        public static bool CheckIfPointsAreEqual(Point point1, Point point2, Diviation diviation)
        {
            bool con = Equasions.CompareValues(point1.GetX(), point2.GetX(), diviation);
            con = con && Equasions.CompareValues(point1.GetY(), point2.GetY(), diviation);
            return con && Equasions.CompareValues(point1.GetZ(), point2.GetZ(), diviation);
        }

        public static Point MultiplyPointByMatrix(Point point, Matrix matrix, double factor)
        {
            return new Point(VectorEquasions.MultiplyVectorByMatrix(new Vector(point), matrix, factor));
        }
    }
}
