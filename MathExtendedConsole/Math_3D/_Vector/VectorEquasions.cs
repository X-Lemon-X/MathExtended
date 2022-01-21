
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
            double x = vector1.GetX() + vector2.GetX();
            double y = vector1.GetY() + vector2.GetY();
            double z = vector1.GetZ() + vector2.GetZ();

            return new Vector(x, y, z);
        }

        public static Vector ScaleVector(Vector vector, double scale)
        {
            return new Vector(vector.GetX() * scale, vector.GetY() * scale, vector.GetZ() * scale);
        }

        public static Vector MultiplyVectorByMatrix(Vector vector, Matrix matrix, double factor)
        {
            double[,] vectorMatrix = new double[4, 4];

            vectorMatrix[0, 0] = vector.GetX();
            vectorMatrix[1, 0] = vector.GetY();
            vectorMatrix[2, 0] = vector.GetZ();

            Matrix matrixVector = new Matrix(vectorMatrix);

            vectorMatrix = MatrixEquasion.MultiplyMatrix(matrix,matrixVector, factor).GetMatrix();

            return new Vector(vectorMatrix[0, 0], vectorMatrix[1, 0], vectorMatrix[2, 0]);
        }

        public static Point MovePointByVector(Point point, Vector vector)
        {
            double x = point.GetX() + vector.GetX();
            double y = point.GetY() + vector.GetY();
            double z = point.GetZ() + vector.GetZ();
            return new Point(x,y,z);
        }

        public static Vector ReSizeVectorToLength(Vector vector, double length)
        {
            double skala = length / vector.GetLength();
            return ScaleVector(vector, skala);
        }
    }
}
