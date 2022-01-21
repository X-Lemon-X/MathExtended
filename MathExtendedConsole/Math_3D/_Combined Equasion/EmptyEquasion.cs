
namespace MathExtended.Math_3D
{
    class EmptyEquasion
    {
        Interval interval;
        public EmptyEquasion(Interval interval)
        {
            this.interval = interval;
        }

        public EmptyEquasion()
        {
            this.interval = new Interval();
        }

        public Point CalculateEquasion(double argument)
        {
            return new Point();
        }

        public Interval GetInterval()
        {
            return interval;
        }
    }
}
