using System.Collections.Generic;

namespace MathExtended.Math_3D
{
    public class CombinedEquasions
    {
        List<Equasion> equasions = new List<Equasion>();
        
        public int AddEquasion(LinearEquasion linearEquasion)
        {
            return AddEquasionInternal(new Equasion(linearEquasion));
        }

        public int AddEquasion(QuadraticEquasion quadraticEquasion)
        {
            return AddEquasionInternal(new Equasion(quadraticEquasion));
        }

        private int AddEquasionInternal(Equasion equasion)
        {
            if (FindEquasionByInterval(equasion) == null)
            {
                equasions.Add(equasion);
                return 1;
            }
            return -1;
        }

        public Point CalculateEquasion(double argument)
        {
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

        public void Rotate(Rotation rotationOX, Rotation rotationOY, double argument)
        {
            Equasion equasion = FindEquasion(argument);
            equasion.Rotate(rotationOX, rotationOY);
        }

        public void RotationCurrent(bool rotationOX, bool rotationOY)
        {
            foreach (Equasion item in equasions)
            {
                item.RotateCurrent(rotationOX,rotationOY);
            }
        }

        private Equasion FindEquasion(double argument)
        {
            foreach (var item in equasions)
            {
                if (IntervalsEquasion.CheckValueInInterval(argument, item.GetInterval()))
                {
                    return item;
                }
            }
            return null;
        }

        private Equasion FindEquasionByInterval(Equasion equasion)
        {
            foreach (var item in equasions)
            {
                if (IntervalsEquasion.CheckIfIntervalsAreConnected(equasion.GetInterval(), item.GetInterval()))
                {
                    return equasion;
                }
            }
            return null;
        }
    }
}
