using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Math_3D;

namespace MathExtended.Pictures
{
    public class ImageMatrixOperations
    {
        public delegate RGBMatrix ProcessingFunction(Matrix matrix);

        public RawPhotoData PrecessImageUsingMatrix(RawPhotoData rawPhotoData, Matrix multiplication, double weight)
        {
            RawPhotoData rwRet = new RawPhotoData(rawPhotoData.GetWidth(), rawPhotoData.GetHight());

            for (int y = 0; y < rawPhotoData.GetHight(); y++)
            {
                for (int x = 0; x < rawPhotoData.GetWidth(); x++)
                {
                    Color rgb = rawPhotoData.Getpixel(x, y);
                    rgb = MultiplyPixel(rgb, multiplication,weight);
                    rwRet.SetPixel(x,y,rgb);
                }
            }
            return rwRet;
        }

        public Color MultiplyPixel(Color color, Matrix matrix, double weight)
        {
            Vector vector = new Vector(color.R, color.G, color.B);
            vector = VectorEquasions.MultiplyVectorByMatrix(vector, matrix,weight);
            return Color.FromArgb(pv(vector.GetX()), pv(vector.GetY()), pv(vector.GetZ()));
        }

        public RGBMatrix MultiplyByMatrix(RGBMatrix rgb ,Matrix matrix)
        {
            Matrix a = rgb.GetMatrixAlpha();
            Matrix b = rgb.GetMatrixBlue();
            Matrix g = rgb.GetMatrixGreen();
            Matrix r = rgb.GetMatrixRed();

            a = MatrixEquasion.MultiplyMatrix(matrix, a, 1);
            b = MatrixEquasion.MultiplyMatrix(matrix, b, 1);
            g = MatrixEquasion.MultiplyMatrix(matrix, g, 1);
            r = MatrixEquasion.MultiplyMatrix(matrix, r, 1);

            return new RGBMatrix(r, b, g, a);
        }

        public int pv(double value)
        {
            return PrepareValueForRGB(value);
        }

        public int PrepareValueForRGB(double value)
        {
            int ret = Math.Abs(Convert.ToInt32(value));
            if (ret > 255)
                return 255;
            else if (ret < 0)
                return 0;
            else
                return ret;
        }
    }

}
