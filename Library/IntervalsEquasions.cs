using System;

namespace MathExtended
{
    public class IntervalsEquasion
    {
        public static bool CheckIfInterval(double argument, Interval interval)
        {
            bool condition1 = BracketCheckLeft(interval.GetBegBracket(), interval.GetBegining(), argument);

            bool condition2 = BracketCheckRight(interval.GetEndBracket(), interval.GetEnd(), argument);

            return condition1 && condition2;
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
