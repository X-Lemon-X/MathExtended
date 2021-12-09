
namespace MathExtended
{
    public class Point
    {
        private double X, Y, Z;
        public Point(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public Point(Vector vector)
        {
            this.X = vector.GetX();
            this.Y = vector.GetY();
            this.Z = vector.GetZ();
        }
        public double GetX()
        {
            return this.X;
        }
        public double GetY()
        {
            return this.Y;
        }
        public double GetZ()
        {
            return this.Z;
        }
    }
}
