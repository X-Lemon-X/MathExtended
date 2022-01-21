namespace MathExtended
{
    public class Interval
    {
        private double beg, end;
        Bracket bracketBeg;
        Bracket bracketEnd;
        IntervalTypes intervalType = IntervalTypes.R;
        
        public Interval(double beg, double end, Bracket bracketBeg, Bracket bracketEnd)
        {
            this.beg = beg;
            this.end = end;
            this.bracketEnd = bracketEnd;
            this.bracketBeg = bracketBeg;
        }

        public Interval(double beg , Bracket bracketBeg)
        {
            this.beg = beg;
            this.bracketBeg = bracketBeg;
            SetPositiveInfinity();
        }

        public Interval(Bracket bracketEnd, double end)
        {
            this.end = end;
            this.bracketEnd = bracketEnd;
            SetNegativeInfinity();
        }

        public Interval()
        {
            SetPositiveInfinity();
            SetPositiveInfinity();
        }

        public void IntervalTypeSet(IntervalTypes intervalType)
        {
            this.intervalType = intervalType;
        }

        public void SetNegativeInfinity()
        {
            beg = double.NegativeInfinity;
            bracketBeg = Bracket.Open;
        }

        public void SetPositiveInfinity()
        {
            end = double.PositiveInfinity;
            bracketEnd = Bracket.Open;
        }

        public double GetBegining()
        {
            return beg;
        }

        public double GetEnd()
        {
            return end;
        }

        public IntervalTypes GetIntervalType()
        {
            return intervalType;
        }

        public Bracket GetEndBracket()
        {
            return bracketEnd;
        }

        public Bracket GetBegBracket()
        {
            return bracketBeg;
        }
    }

    public enum Bracket
    {
        Open = 1,
        Close = 2,
    }

    public enum IntervalTypes
    { 
        N = 1,
        Z = 2,
        Q = 3,
        R = 4,
        NQ = 5
    }
}
