
namespace MathExtended
{
    public class LinearEquasion
    {
        private double tangens;
        Vector vector;
        double rotationX=1, rotationY=1;
        Interval interval;
        public LinearEquasion(double tangens, Vector vector, Interval interval)
        {
            this.tangens = tangens;
            this.vector = vector;
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

        public Point CalculateFunction(double argument)
        {

            if (!IntervalsEquasion.CheckValueInInterval(argument, interval))
            {
                return new Point();
            }

            double Y = argument - vector.GetX();
            
            Y *= rotationX;
            Y *= tangens;
            Y += vector.GetY();

            Y *= rotationY;

            return new Point(argument,Y,vector.GetZ());
        }

        public Interval GetInterval()
        {
            return interval;
        }
    }
}
