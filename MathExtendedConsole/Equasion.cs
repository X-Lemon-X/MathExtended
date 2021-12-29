using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    public class Equasion
    {
        public delegate Point MethodDelegate(double a);

        public delegate Point DelegatePoint(double argumet);

        EmptyEquasion emptyEq = new EmptyEquasion();
        LinearEquasion linear;
        QuadraticEquasion quadratic;
        PeriodicLinearEquasion periodicLinearEquasion;
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

        public Equasion(PeriodicLinearEquasion periodicLinearEquasion)
        {
            this.periodicLinearEquasion = periodicLinearEquasion;
            this.type = EquasionsType.PeriodicLinear;
        }

        public Equasion()
        {
            type = EquasionsType.Null;
        }

        public Interval GetInterval()
        {
            return interval;
        }

        public EquasionsType GetEquasionType()
        {
            return type;
        }

        public Point CalculateArgument(double argument)
        {

           // Dictionary<EquasionsType, Delegate> dictCal = new Dictionary<EquasionsType, Delegate>();

            //dictCal.Add(EquasionsType.Null, new DelegatePoint(emptyEq.CalculateEquasion));
            //dictCal.Add(EquasionsType.Linear, new DelegatePoint(linear.CalculateFunction));
            //dictCal.Add(EquasionsType.Quadratic, new DelegatePoint(quadratic.CalculateFuntion));
            //dictCal.Add(EquasionsType.PeriodicLinear, new DelegatePoint(periodicLinearEquasion.CalculateFunction));

            //var obj =  dictCal[type].DynamicInvoke( argument);

            //return (Point)obj;

            switch (type)
            {
                case EquasionsType.Null:
                    return new Point();
                    break;

                case EquasionsType.Linear:
                    return linear.CalculateFunction(argument);
                    break;

                case EquasionsType.Quadratic:
                    return quadratic.CalculateFuntion(argument);
                    break;

                case EquasionsType.PeriodicLinear:
                    return periodicLinearEquasion.CalculateFunction(argument);
                    break;
            }

            return new Point();
        }
    }
}
