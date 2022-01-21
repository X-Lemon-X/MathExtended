using System;

namespace MathExtended
{
    public class Vector
    {
        private double X, Y, Z;
        public Vector(double x, double y, double z) 
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public Vector(Point point)
        {
            this.X = point.GetX();
            this.Y = point.GetY();
            this.Z = point.GetZ();
        }
        public Vector(Point pointBeg, Point pointEnd)
        {
            this.X = pointEnd.GetX() - pointBeg.GetX();
            this.Y = pointEnd.GetY() - pointBeg.GetY();
            this.Z = pointEnd.GetZ() - pointBeg.GetZ();
        }
        public Vector()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;

        }
        public double GetLength()
        {
            return Math.Sqrt(X*X + Y*Y + Z*Z);
        }
        public double GetX() 
        {
            return this.X;
        }
        public double GetY()
        {
            return this.Y;
        }
        public double GetZ()
        {
            return this.Z;
        }
    }
}
