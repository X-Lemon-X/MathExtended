
namespace MathExtended
{
    class VectorEquasions
    {
        public Vector AddVectors(Vector vector1, Vector vector2)
        { 
            double x = vector1.GetX() + vector2.GetX();
            double y = vector1.GetY() + vector2.GetY();
            double z = vector1.GetZ() + vector2.GetZ();

            return new Vector(x, y, z);
        }

        public Vector ScaleVector(Vector vector, double scale)
        {
            return new Vector(vector.GetX() * scale, vector.GetY() * scale, vector.GetZ() * scale);
        }

        public Vector MultiplyVectorByMatrix(Vector vector, Matrix matrix, double factor)
        {
            double[,] vectorMatrix = new double[4, 4];

            vectorMatrix[0, 0] = vector.GetX();
            vectorMatrix[1, 0] = vector.GetY();
            vectorMatrix[2, 0] = vector.GetZ();

            Matrix matrixVector = new Matrix(vectorMatrix);
            MatrixEquasion eq = new MatrixEquasion();

            vectorMatrix = eq.MultiplyMatrix(matrix,matrixVector, factor).GetMatrix();

            return new Vector(vectorMatrix[0, 0], vectorMatrix[1, 0], vectorMatrix[2, 0]);
        }

        public Point MultiplyPointByMatrix(Point point, Matrix matrix, double factor)
        {
            return new Point(MultiplyVectorByMatrix(new Vector(point), matrix, factor));
        }

        public Point MovePointByVector(Point point, Vector vector)
        {
            double x = point.GetX() + vector.GetX();
            double y = point.GetY() + vector.GetY();
            double z = point.GetZ() + vector.GetZ();
            return new Point(x,y,z);
        }

        public Vector ReSizeVectorToLength(Vector vector, double length)
        {
            double skala = length / vector.GetLength();
            return ScaleVector(vector, skala);
        }
    }
}
