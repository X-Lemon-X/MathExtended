
namespace MathExtended
{
    public class QuadraticEquasion
    {
        double A, B, rotationX, rotationY;
        Vector vector;
        Interval interval;

        public QuadraticEquasion(double A, double B, double C)
        {
            this.A = A;
            this.B = B;
            this.vector = new Vector(0,C,0);
            interval = new Interval();
        }

        public QuadraticEquasion(Vector vector, double A, double B, Interval interval)
        {
            this.vector = vector;
            this.A = A;
            this.B = B;
            this.interval = interval;
        }
        public void Rotate(Rotation rotationOX, Rotation rotationOY)
        {
            if (rotationOX == Rotation.OX) rotationX = -1.0;
            if (rotationOX == Rotation.NOX) rotationX = 1.0;

            if (rotationOY == Rotation.OY) rotationY = -1.0;
            if (rotationOY == Rotation.NOY) rotationY = 1.0;
        }

        public Point CalculateFuntion(double argument)
        {
            argument -= vector.GetX();
            argument *= rotationX;
            double Y = (A * argument * argument) + (B * argument) + vector.GetY();
            return new Point(argument,Y* rotationY,vector.GetZ());
        }
    }
}
