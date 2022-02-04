using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Math_3D;

namespace MathExtended.Pictures
{
    public class ImageMatrixOperations
    {
        public delegate RGBMatrix ProcessingFunction(Matrix matrix);

        public RawPhotoData PrecessImageMask(RawPhotoData rawPhotoData, Matrix multiplication)
        {
            RawPhotoData rwRet = new RawPhotoData(rawPhotoData.GetWidth(), rawPhotoData.GetHight());

            double weight = 1.0;

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
                    Color[,] rgb = rawPhotoData.GetMatrixColors(x, y);
                    rwRet.SetPixel(x, y, AddPixels(rgb, multiplication));
                }
            }
            return rwRet;

        }

        public RawPhotoData RemoveMetadata(RawPhotoData rawPhotoData)
        {
            Image image = rawPhotoData.GetImage();

            foreach (var item in image.PropertyItems)
            {
                int length = item.Len;
                item.Value = new byte[length];
                image.SetPropertyItem(item);
            }
            return rawPhotoData;
        }

        private Color MultiplyPixel(Color color, Matrix matrix, double weight)
        {
            Vector vector = new Vector(color.R, color.G, color.B);
            vector = VectorEquasions.MultiplyVectorByMatrix(vector, matrix,weight);
            return Color.FromArgb(pv(vector.GetX()), pv(vector.GetY()), pv(vector.GetZ()));
        }

        private Color AddPixels(Color[,] color, Matrix matrix)
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

        private int pv(double value)
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

    public class ImageManipulationMatrixs
    {
        public static readonly Matrix EdgeDetection = new Matrix(new double[,]
            {
              { -1, -1, -1 ,0},
              { -1, 8, -1 ,0},
              { -1, -1, -1,0},
              { 0,0,0,0},
            }
        );

        public static readonly Matrix GrayScale = new Matrix(new double[,]
             {
              { 1.0/3, 1.0/3, 1.0/3 ,0},
              { 1.0/3, 1.0/3, 1.0/3,0},
              { 1.0/3, 1.0/3, 1.0/3,0},
              { 0,0,0,0},
             }
         );

        public static readonly Matrix Sharpen = new Matrix(new double[,]
            {
              { 0,-1,0 ,0},
              {-1,5,-1,0},
              {0,-1,0,0},
              { 0,0,0,0},
            }
        );

        public static readonly Matrix Blur = new Matrix(new double[,]
          {
             { 0.0625, 0.125, 0.0625,0 },
             { 0.125, 0.25, 0.125,0 },
             { 0.0625, 0.125, 0.0625,0 },
              { 0,0,0,0}
          }
        );
    }
}
