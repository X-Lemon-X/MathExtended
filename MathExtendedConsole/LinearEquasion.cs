using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended
{
    class LinearEquasion
    {
        private double tangens;
        Vector vector;
        double rotationX=1, rotationY=1;
        public LinearEquasion(double tangens, Vector vector)
        {
            this.tangens = tangens;
            this.vector = vector;
        }

        public void Rotate(Rotation rotationOX, Rotation rotationOY)
        {
            if (rotationOX == Rotation.OX) rotationX = -1.0;
            if (rotationOX == Rotation.NOX) rotationX = 1.0;

            if (rotationOY == Rotation.OY) rotationY = -1.0;
            if (rotationOY == Rotation.NOY) rotationY = 1.0;
        }

        public Point CalculateEquasion(double argument)
        {
            double Y = argument - vector.GetX();
            
            Y *= rotationX;
            Y *= tangens;
            Y += vector.GetY();

            Y *= rotationY;

            return new Point(argument,Y,vector.GetZ());
        }

    }
}
