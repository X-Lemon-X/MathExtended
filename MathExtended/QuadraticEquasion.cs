
namespace MathExtended
{
    public class QuadraticEquasion
    {
        double A, B;
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

        public Point CalculateFuntion(double argument)
        {
            double Y = (A * argument * argument) + (B * argument) + vector.GetY();
            return new Point(argument,Y,vector.GetZ());
        }
    }
}
