
namespace MathExtended
{
    public class PeriodicFunctionLinear
    {
        private double tangens, period;
        private int rotateOX=1, rotateOY=1;
        private Vector vector;
        private bool BeginAtZero=true;
        public PeriodicFunctionLinear(double tangens, Vector vector, double period, bool BeginAtZero)
        {
            this.vector = vector;
            this.tangens = tangens;
            this.period = period;
            this.BeginAtZero = BeginAtZero;
        }
        public void RotateOX(bool value)
        {
            if (value) rotateOX = -1;
            else rotateOX = 1;
        }
        public void RotateOY(bool value)
        {
            if (value) rotateOY = -1;
            else rotateOY = 1;
        }
        public Point CalculateFunction(double argument)
        {
            double Y;

            Y = argument - vector.GetX();
            Y *= rotateOY;
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
            Y *= rotateOX;
            
            return new Point(argument,Y,vector.GetZ());
        }

    }
}
