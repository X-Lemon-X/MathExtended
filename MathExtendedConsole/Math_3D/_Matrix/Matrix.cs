namespace MathExtended.Math_3D
{
    public class Matrix
    {
        private double[,] matrix;
        public Matrix(double[,] matrix)
        {
            if (matrix.Length == 16)
                this.matrix = matrix;
            else
                SetIdentity();
            
        }
        public Matrix(Matrix matrix)
        {
            this.matrix = matrix.GetMatrix();
        }
        public Matrix()
        {
            SetIdentity();
        }
        public double[,] GetMatrix()
        {
            return this.matrix;
        }
        public void SetIdentity()
        {
            double[,] matrixIdentity =
            {
                { 1,0,0,0 },
                { 0,1,0,0 },
                { 0,0,1,0 },
                { 0,0,0,1 }
            };

            matrix = matrixIdentity;
        }

    }
}
