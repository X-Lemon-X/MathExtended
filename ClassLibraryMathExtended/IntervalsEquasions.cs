using System;

namespace MathExtended
{
    class IntervalsEquasion
    {
        public bool CheckIfInterval(double argument, Interval interval)
        {
            bool condition = BracketCheck(interval.GetBegBracket(), interval.GetBegining(), argument, false);

            bool condition2 = BracketCheck(interval.GetEndBracket(), interval.GetEnd(), argument, true);

            return condition && condition2;
        }

        private bool BracketCheck(Bracket bracket, double value, double valueCompared, bool smaller)
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

        public bool CheckIfValueIsNatural(double argument)
        {
            double val = argument / Convert.ToDouble((int)(argument));
            if (val == 1.0 && argument > 0) return true;
            else return false;
        }

        public bool CheckIfValueIsInteger(double argument)
        {
            double val = argument / Convert.ToDouble((int)(argument));
            if (val == 1.0 ) return true;
            else return false;
        }

    }
}
