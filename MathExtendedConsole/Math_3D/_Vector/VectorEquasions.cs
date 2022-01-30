

namespace MathExtended.Math_3D
{
    public class VectorEquasions
    {
        public static bool CheckIfVectorsAreEqual(Vector vector1, Vector vector2, Diviation diviation)
        {
            bool con = Equasions.CompareValues(vector1.GetX(), vector2.GetX(), diviation);
            con = con && Equasions.CompareValues(vector1.GetY(), vector2.GetY(), diviation);
            return con && Equasions.CompareValues(vector1.GetZ(), vector2.GetZ(), diviation);
        }
        public static Vector AddVectors(Vector vector1, Vector vector2)
        { 
            return new Vector(vector1.GetX() + vector2.GetX(), vector1.GetY() + vector2.GetY(), vector1.GetZ() + vector2.GetZ());
        }
        public static Vector ScaleVector(Vector vector, double scale)
        {
            return new Vector(vector.GetX() * scale, vector.GetY() * scale, vector.GetZ() * scale);
        }
        public static Vector ReverseVector(Vector vector)
        {
            return new Vector(vector.GetX() * -1.0, vector.GetY() * -1.0, vector.GetZ() * -1.0);
        }
        public static Vector MultiplyVectorByMatrix(Vector vector, Matrix matrix, double factor)
        {
            double[] matrixR = { vector.GetX(), vector.GetY(), vector.GetZ(),1};
            double[] matrixReturn = new double[4];

            for (int i = 0; i < 3; i++)
            {
                for (int p = 0; p < 4; p++)
                {
                    matrixReturn[i] += matrix.GetMatrix()[i, p] * matrixR[p];
                }
                matrixReturn[i] *= factor;
            }

            return new Vector(matrixReturn[0], matrixReturn[1], matrixReturn[2]);
        }
        public static Point MovePointByVector(Point point, Vector vector)
        {
            return new Point(point.GetX() + vector.GetX(), point.GetY() + vector.GetY(), point.GetZ() + vector.GetZ());
        }
        public static Vector ReSizeVectorToLength(Vector vector, double length)
        {
            double skala = length / vector.GetLength();
            return ScaleVector(vector, skala);
        }
    }
}
