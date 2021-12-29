
namespace MathExtended
{
    public class PeriodicLinearEquasion
    {
        private double tangens, period;
        private int rotationX = 1, rotationY = 1;
        private Vector vector;
        private bool BeginAtZero=true;
        public PeriodicLinearEquasion(double tangens, Vector vector, double period, bool BeginAtZero)
        {
            this.vector = vector;
            this.tangens = tangens;
            this.period = period;
            this.BeginAtZero = BeginAtZero;
        }
        public void Rotate(Rotation rotationOX, Rotation rotationOY)
        {
            if (rotationOX == Rotation.OX) rotationX = -1;
            if (rotationOX == Rotation.NOX) rotationX = 1;

            if (rotationOY == Rotation.OY) rotationY = -1;
            if (rotationOY == Rotation.NOY) rotationY = 1;
        }
        public Point CalculateFunction(double argument)
        {
            double Y;

            Y = argument - vector.GetX();
            Y *= rotationX;
            Y = Y % period;

            if (BeginAtZero)
            {
                if (Y < 0) Y = period + Y;
            }
            else
            {
                if (Y <= 0) Y = period + Y;
            }

            Y *= tangens;
            Y += vector.GetY();
            Y *= rotationY;
            
            return new Point(argument,Y,vector.GetZ());
        }

    }
}
