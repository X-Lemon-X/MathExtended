using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    public class CombineEquasions
    {
        List<Equasion> equasions = new List<Equasion>();
        
        public void AddEquasion(LinearEquasion linearEquasion)
        {
            Equasion equasion = new Equasion(linearEquasion);
            equasions.Add(equasion);
        }

        public void AddEquasion(QuadraticEquasion quadraticEquasion)
        {
            Equasion equasion = new Equasion(quadraticEquasion);
            equasions.Add(equasion);
        }

        public Point CalculateEquasion(double argument)
        {
            foreach (var item in equasions)
            {
                if (IntervalsEquasion.CheckIfInterval(argument, item.GetInterval()))
                {
                    return item.CalculateArgument(argument);                 
                }
            }

            return new Point();
        }

    }

    class Equasion
    {
        LinearEquasion linear;
        QuadraticEquasion quadratic;
        EquasionsType type;
        Interval interval;

        public Equasion(LinearEquasion linearEquasion)
        {
            this.linear = linearEquasion;
            this.interval = linearEquasion.GetInterval();
            this.type = EquasionsType.Linear;
        }

        public Equasion(QuadraticEquasion quadraticEquasion)
        {
            this.quadratic = quadraticEquasion;
            this.interval = quadraticEquasion.GetInterval();
            this.type = EquasionsType.Quadratic;
        }

        public Interval GetInterval()
        {
            return interval;
        }
 
        public Point CalculateArgument(double argument)
        {
            switch (type)
            {
                case EquasionsType.Linear: return linear.CalculateEquasion(argument);
                    break;
                case EquasionsType.Quadratic: return quadratic.CalculateFuntion(argument);
                    break;
            }

            return new Point();
        }
    }

    public enum EquasionsType
    { 
        Linear=1,
        Quadratic = 2,
    }
}
