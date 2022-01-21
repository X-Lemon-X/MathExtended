using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
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
