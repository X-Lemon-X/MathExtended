using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    public class CombinedEquasions
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
            //return FindEquasion(argument).CalculateArgument(argument);

            foreach (var item in equasions)
            {
                Point point = item.CalculateArgument(argument);
                if (!point.CheckIfPointIsEmpty())
                {
                    return point;
                }
            }

            return new Point();
        }

        public EquasionsType GetEquasionsType(double argument)
        {
            return FindEquasion(argument).GetEquasionType();
        }

        private Equasion FindEquasion(double argument)
        {
            foreach (var item in equasions)
            {
                if (IntervalsEquasion.CheckIfInterval(argument, item.GetInterval()))
                {
                    return item;
                }
            }
            return new Equasion();
        }

    }

}
