using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MathExtended.Pictures.RGB_Matrix;

namespace MathExtended.Pictures
{
    public class RawPhotoData
    {
        Bitmap picture;
        int x, y;

        public RawPhotoData(int width, int height)
        {
            picture = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            x = width;
            y = height;
        }

        public void GetDataFromImage(string path)
        {
            if (File.Exists(path))
            {
                Image image = Image.FromFile(path);
                picture = new Bitmap(image);
            }
            else
            {
                throw new FileNotFoundException("File: " + path + " not found!");
            }
        }

        public void SetPixel(int x, int y, Color color)
        {
            CheckIfCordinantsFit(x, y);
            picture.SetPixel(x, y, color);
        }

        public Color Getpixel(int x, int y)
        {
            CheckIfCordinantsFit(x, y);
            return picture.GetPixel(x, y);
        }

        public RGBMatrix GetMatrix(int x, int y)
        {
            CheckIfCordinantsFit(x, y);
            Color[,] pixels =
            {
                {Rcc(x - 1, y - 1),  Rcc(x, y - 1),  Rcc(x + 1, y - 1)},
                {Rcc(x - 1, y),      Rcc(x, y),      Rcc(x + 1, y) },
                {Rcc(x - 1, y + 1),  Rcc(x, y + 1),  Rcc(x + 1, y + 1)},
            };

            return new RGBMatrix(pixels);
        }

        private Color Rcc(int x, int y)
        {
            return picture.GetPixel(CheckX(x), CheckY(y));
        }

        private int CheckX(int x)
        {
            if (x > this.x)
                return this.x;
            else if (x < 0)
                return 0;
            else
                return x;
        }
        private int CheckY(int y)
        {
            if (y > this.y)
                return this.y;
            else if (y < 0)
                return 0;
            else
                return y;
        }

        private void CheckIfCordinantsFit(int x, int y)
        {
            if (x > this.x || y > this.y)
                throw new InvalidDataException("x or y value are aou of boundries");
                
        }

    }
}
