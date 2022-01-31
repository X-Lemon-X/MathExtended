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

        public RawPhotoData PrecessImageMask(RawPhotoData rawPhotoData, Matrix multiplication, double weight)
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

        public RawPhotoData PrecessImagePixels(RawPhotoData rawPhotoData, Matrix multiplication)
        {
            RawPhotoData rwRet = new RawPhotoData(rawPhotoData.GetWidth(), rawPhotoData.GetHight());

            for (int y = 0; y < rawPhotoData.GetHight(); y++)
            {
                for (int x = 0; x < rawPhotoData.GetWidth(); x++)
                {
                    Color[,] rgb = rawPhotoData.GetMatrix(x, y);
                    rwRet.SetPixel(x, y, AddPixels(rgb, multiplication));
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

        public Color AddPixels(Color[,] color, Matrix matrix)
        {
            double R = 0, G = 0, B = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int p = 0; p < 3; p++)
                {
                    R += color[i, p].R * matrix.GetMatrix()[i, p];
                    G += color[i, p].G * matrix.GetMatrix()[i, p];
                    B += color[i, p].B * matrix.GetMatrix()[i, p];
                }
            }
            return Color.FromArgb(pv(Convert.ToInt32(R)), pv(Convert.ToInt32(G)), pv(Convert.ToInt32(B)));
        }

        public int pv(double value)
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
