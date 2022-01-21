
namespace MathExtended.Math_3D
{
    public class QuadraticEquasion
    {
        double A, B, rotationX=1, rotationY=1;
        Vector vector;
        Interval interval;

        public QuadraticEquasion(double A, double B, double C, Interval interval)
        {
            this.A = A;
            this.B = B;
            this.vector = new Vector(0,C,0);
            this.interval = interval;
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

        public void RotateCurrent(bool rotationOX, bool rotationOY)
        {
            if (rotationOX) rotationX *= -1.0;
            if (rotationOY) rotationY *= -1.0;
        }

        public Point CalculateFuntion(double argument)
        {
            if (!IntervalsEquasion.CheckValueInInterval(argument, interval))
            {
                return new Point();
            }

            argument -= vector.GetX();
            argument *= rotationX;
            double Y = (A * argument * argument) + (B * argument) + vector.GetY();
            return new Point(argument, Y * rotationY, vector.GetZ());
   
        }

        public Interval GetInterval()
        {
            return interval;
        }
    }
}
