using System;

namespace MathExtended
{
    public class IntervalsEquasion
    {
        public static bool CheckIfInterval(double argument, Interval interval)
        {
            bool condition = BracketCheck(interval.GetBegBracket(), interval.GetBegining(), argument, false);

            bool condition2 = BracketCheck(interval.GetEndBracket(), interval.GetEnd(), argument, true);

            return condition && condition2;
        }

        private static bool BracketCheck(Bracket bracket, double value, double valueCompared, bool smaller)
        {
            if (smaller)
            {
                if (bracket == Bracket.Close)
                    return valueCompared <= value;

                if (bracket == Bracket.Open)
                    return valueCompared < value;
            }
            else
            {
                if (bracket == Bracket.Close)
                    return valueCompared >= value;

                if (bracket == Bracket.Open)
                    return valueCompared > value;
            }

            return false;
        }

    }
}
