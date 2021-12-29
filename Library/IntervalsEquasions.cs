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
                return false;
            }
            else if (CompareTo.GetEnd() == interval.GetBegining())
            {
                return !((CompareTo.GetEndBracket() != interval.GetBegBracket()) || (CompareTo.GetEndBracket() == Bracket.Open && interval.GetBegBracket() == Bracket.Open));
            }
            else if (CompareTo.GetBegining() == interval.GetEnd())
            {
                return !((CompareTo.GetBegBracket() != interval.GetEndBracket()) || (CompareTo.GetBegBracket() == Bracket.Open && interval.GetEndBracket()==Bracket.Open));            
            }

            return true;
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
