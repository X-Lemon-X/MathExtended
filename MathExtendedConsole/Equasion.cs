using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    public class Equasion
    {
        public delegate Point DelegatePoint(double argumet);
        public delegate Interval DelegateInterval();
        DelegatePoint delPoint;
        DelegateInterval delInterval;
        EquasionsType type;
       
        public Equasion(LinearEquasion linearEquasion)
        {
            this.type = EquasionsType.Linear;
            this.delPoint = linearEquasion.CalculateFunction;
            this.delInterval = linearEquasion.GetInterval;
        }

        public Equasion(QuadraticEquasion quadraticEquasion)
        {
            this.type = EquasionsType.Quadratic;
            this.delPoint = quadraticEquasion.CalculateFuntion;
            this.delInterval = quadraticEquasion.GetInterval;

        }

        public Equasion(PeriodicLinearEquasion periodicLinearEquasion)
        {
            this.type = EquasionsType.PeriodicLinear;
            this.delPoint = periodicLinearEquasion.CalculateFunction;
            this.delInterval = periodicLinearEquasion.GetInterval;
        }

        public Equasion()
        {
            type = EquasionsType.Null;
        }

        public Interval GetInterval()
        {
            return delInterval();
        }

        public EquasionsType GetEquasionType()
        {
            return type;
        }

        public Point CalculateArgument(double argument)
        {
            return delPoint(argument);
        }
    }
}
