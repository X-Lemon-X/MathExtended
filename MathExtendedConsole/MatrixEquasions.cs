using System;

namespace MathExtended
{
    public class MatrixEquasion
    {
        public Matrix MatrixRotationX(Matrix matrixToBeRotated, double angle)
        {
            double[,] matrixTable =
            {
                {1, 0, 0, 0 },
                {0, Math.Cos(angle), -Math.Sin(angle), 0},
                {0, Math.Sin(angle), Math.Cos(angle), 0},
                {0, 0, 0, 1 }
            };

            Matrix matrix = new Matrix(matrixTable);

            return MultiplyMatrix(matrix,matrixToBeRotated,1);
        }

        public Matrix MatrixRotationY(Matrix matrixToBeRotated, double angle)
        {
            double[,] matrixTable =
            {
                {Math.Cos(angle), 0, Math.Sin(angle), 0 },
                {0, 1, 0, 0},
                {-Math.Sin(angle), 0, Math.Cos(angle), 0},
                {0, 0, 0, 1 }
            };

            Matrix matrix = new Matrix(matrixTable);

            return MultiplyMatrix(matrix, matrixToBeRotated, 1);
        }
        
        public Matrix MatrixRotationZ(Matrix matrixToBeRotated, double angle)
        {
            double[,] matrixTable =
            {
                {Math.Cos(angle), -Math.Sin(angle), 0, 0 },
                {Math.Sin(angle), Math.Cos(angle), 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1 }
            };

            Matrix matrix = new Matrix(matrixTable);

            return MultiplyMatrix(matrix, matrixToBeRotated, 1);
        }
        
        public Matrix MatrixAdd(Matrix matrix1, Matrix matrix2)
        {
            double[,] matrixRet = new double[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int p = 0; p < 4; p++)
                {
                    matrixRet[i, p] = matrix1.GetMatrix()[i, p] + matrix2.GetMatrix()[i, p];
                }
            }

            return new Matrix(matrixRet);
        }
        
        public Matrix MatrixSubtract(Matrix matrixFrom, Matrix matrixSubtract)
        {
            double[,] matrixRet = new double[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int p = 0; p < 4; p++)
                {
                    matrixRet[i, p] = matrixFrom.GetMatrix()[i, p] - matrixSubtract.GetMatrix()[i, p];
                }
            }
            return new Matrix(matrixRet);
        }
        
        public Matrix MatrixScale(Matrix matrix, double scale)
        {
            double[,] matrixRet = new double[4,4];
            for (int i = 0; i < 4; i++)
            {
                for (int p = 0; p < 4; p++)
                {
                    matrixRet[i, p] = matrix.GetMatrix()[i, p] * scale;
                }
            }
            return new Matrix(matrixRet);
        }
        
        public Matrix MultiplyMatrix(Matrix matrixLeft,Matrix matrixRight, double factor)
        {
            double[,] matrixL = matrixLeft.GetMatrix();
            double[,] matrixR = matrixRight.GetMatrix();
            double[,] matrixReturn = new double[4, 4];
            
            for (int i = 0; i < 4; i++)
            {
                for (int p = 0; p < 4; p++)
                {
                    for (int h = 0; h < 4; h++)
                    {
                        matrixReturn[i, p] += matrixL[i, h] * matrixR[h, p];
                    }
                    matrixReturn[i, p] *= factor;
                }
            }
            return new Matrix(matrixReturn);
        }
    }
}
