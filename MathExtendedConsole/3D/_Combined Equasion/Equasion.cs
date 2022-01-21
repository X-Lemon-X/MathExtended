

namespace MathExtended
{
    public class Equasion
    {
        public delegate Point DelegatePoint(double argumet);
        public delegate Interval DelegateInterval();
        public delegate void DelegateRotate(Rotation rotationX, Rotation rotationY);
        public delegate void DelageteRotationCurrent(bool rotationOX, bool rotationOY);
        DelegatePoint delPoint;
        DelegateInterval delInterval;
        DelegateRotate delegateRotate;
        DelageteRotationCurrent delageteRotationCurrent;
        EquasionsType type;

        public Equasion(LinearEquasion linearEquasion)
        {
            this.type = EquasionsType.Linear;
            this.delPoint = linearEquasion.CalculateFunction;
            this.delInterval = linearEquasion.GetInterval;
            this.delegateRotate = linearEquasion.Rotate;
            this.delageteRotationCurrent = linearEquasion.RotateCurrent;
        }

        public Equasion(QuadraticEquasion quadraticEquasion)
        {
            this.type = EquasionsType.Quadratic;
            this.delPoint = quadraticEquasion.CalculateFuntion;
            this.delInterval = quadraticEquasion.GetInterval;
            this.delegateRotate = quadraticEquasion.Rotate;
            this.delageteRotationCurrent = quadraticEquasion.RotateCurrent;
        }

        public Equasion(PeriodicLinearEquasion periodicLinearEquasion)
        {
            this.type = EquasionsType.PeriodicLinear;
            this.delPoint = periodicLinearEquasion.CalculateFunction;
            this.delInterval = periodicLinearEquasion.GetInterval;
            this.delegateRotate = periodicLinearEquasion.Rotate;
            this.delageteRotationCurrent = periodicLinearEquasion.RotateCurrent;
        }

        public Equasion()
        {
            type = EquasionsType.Null;
        }

        public void Rotate(Rotation rotationOX, Rotation rotationOY)
        {
            delegateRotate(rotationOX,rotationOY);
        }

        public void RotateCurrent(bool rotationOX, bool rotationOY)
        {
            delageteRotationCurrent(rotationOX,rotationOY);
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
