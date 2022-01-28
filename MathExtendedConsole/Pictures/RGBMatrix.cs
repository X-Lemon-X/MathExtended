using System;
using System.Drawing;
using MathExtended.Math_3D;

namespace MathExtended.Pictures
{
    public class RGBMatrix
    {
        private Matrix matrixRed, matrixBlue, matrixGreen, matrixAlpha;

        public RGBMatrix(Color[,] colors) 
        {
            if (colors.GetLength(0) == 3 && colors.GetLength(1) == 3 && colors.Length == 9)
            {
                Matrix[] mM = CreateMatrixFromColor(colors);
                matrixRed = mM[0];
                matrixBlue = mM[1];
                matrixGreen = mM[2];
                matrixAlpha = mM[3];
            }
            else
            {
                throw new ArgumentException("Colors need to be 3 by 3!");
            }
        }

        public RGBMatrix(Matrix mRed, Matrix mBlue, Matrix mGreen, Matrix mAlpha)
        {
            matrixAlpha = mAlpha;
            matrixBlue = mBlue;
            matrixGreen = mGreen;
            matrixRed = mRed;
        }

        private Matrix[] CreateMatrixFromColor(Color[,] rgb)
        {
            double[,] 
            dR = new double[4,4], 
            dB = new double[4, 4],
            dG = new double[4, 4],
            dA = new double[4, 4];

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    dR[i, k] = Convert.ToDouble(rgb[i, k].R);
                    dB[i, k] = Convert.ToDouble(rgb[i, k].B);
                    dG[i, k] = Convert.ToDouble(rgb[i, k].G);
                    dA[i, k] = Convert.ToDouble(rgb[i, k].A);
                }
            }

            Matrix[] retM = {
                new Matrix(dR),
                new Matrix(dB),
                new Matrix(dG),
                new Matrix(dA)};

            return retM;
        }

        private Color[,] CreateColorsFromatrix(Matrix mr, Matrix mb, Matrix mg, Matrix ma)
        {
            Color[,] rgb = new Color[4, 4];

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    rgb[i, k] = Color.FromArgb(pv(ma.GetMatrix()[i, k]), pv(mr.GetMatrix()[i, k]), pv(mg.GetMatrix()[i, k]), pv(mb.GetMatrix()[i, k]));
                }
            }

            return rgb;
        }

        public int pv(double value)
        {
            return PrepareValueForRGB(value);
        }

        public int PrepareValueForRGB(double value)
        {
            int ret = Convert.ToInt32(value);

            if (ret > 255)
                return 255;
            else if (ret < 0)
                return 0;
            else
                return ret;
        }

        public Matrix GetMatrixRed()
        {
            return matrixRed;
        }

        public Matrix GetMatrixBlue()
        {
            return matrixBlue;
        }

        public Matrix GetMatrixGreen()
        {
            return matrixGreen;
        }

        public Matrix GetMatrixAlpha()
        {
            return matrixAlpha;
        }

        public Color[,] GetColors()
        {
            return CreateColorsFromatrix(matrixRed,matrixBlue,matrixGreen,matrixAlpha);
        }
    }
}
