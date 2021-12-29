using System;

namespace MathExtended
{
    public class IntervalsEquasion
    {
        public static bool CheckValueInInterval(double argument, Interval interval)
        {
            bool condition1 = BracketCheckLeft(interval.GetBegBracket(), interval.GetBegining(), argument);

            bool condition2 = BracketCheckRight(interval.GetEndBracket(), interval.GetEnd(), argument);

            return condition1 && condition2;
        }

        public static bool CheckIfIntervalsAreConnected(Interval CompareTo, Interval interval)
        {
            if (CompareTo.GetEnd() < interval.GetBegining() || CompareTo.GetBegining() > interval.GetEnd())
            {
                return true;
            }
            else if (CompareTo.GetEnd() == interval.GetBegining())
            {
                return CompareTo.GetEndBracket() != interval.GetBegBracket();
            }
            else if (CompareTo.GetBegining() == interval.GetEnd())
            {
                return CompareTo.GetBegBracket() != interval.GetEndBracket();            
            }

            return false;
        }

        private static bool BracketCheckLeft(Bracket bracket, double value, double valueCompared)
        {
            if (bracket == Bracket.Close)
                return valueCompared >= value;

            if (bracket == Bracket.Open)
                return valueCompared > value;

            return false;
        }

        private static bool BracketCheckRight(Bracket bracket, double value, double valueCompared)
        {
            if (bracket == Bracket.Close)
                return valueCompared <= value;

            if (bracket == Bracket.Open)
                return valueCompared < value;
            
            return false;
        }

    }
}
