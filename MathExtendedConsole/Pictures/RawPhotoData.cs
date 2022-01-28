using System.Drawing;
using System.IO;

namespace MathExtended.Pictures
{
    public class RawPhotoData
    {
        Bitmap picture;
        int x, y;
        public RawPhotoData(string path)
        {
            if (File.Exists(path))
            {
                Image image = Image.FromFile(path);
                x = image.Width;
                y = image.Height;
                picture = new Bitmap(image);
            }
            else
            {
                throw new FileNotFoundException("File: " + path + " not found!");
            }
        }

        public RawPhotoData(int width, int height)
        {
            x = width;
            y = height;
            picture = new Bitmap(width,height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        public void SetPixel(int x, int y, Color color)
        {
            CheckIfCordinantsFit(x, y);
            picture.SetPixel(x, y, color);
        }

        public void SetMatrixMiddlePoint(int x, int y, RGBMatrix rgb)
        {
            CheckIfCordinantsFit(x, y);

            int a = rgb.pv(rgb.GetMatrixAlpha().GetMatrix()[1,1]);
            int b = rgb.pv(rgb.GetMatrixBlue().GetMatrix()[1, 1]);
            int g = rgb.pv(rgb.GetMatrixGreen().GetMatrix()[1, 1]);
            int r = rgb.pv(rgb.GetMatrixRed().GetMatrix()[1, 1]);

            Color color = Color.FromArgb(a, r, g, b);

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
            if (x >= this.x)
                return this.x-1;
            else if (x <= 0)
                return 0;
            else
                return x;
        }
        
        private int CheckY(int y)
        {
            if (y >= this.y)
                return this.y - 1;
            else if (y <= 0)
                return 0;
            else
                return y;
        }

        public int GetWidth()
        {
            return x;
        }

        public int GetHight()
        {
            return y;
        }

        private void CheckIfCordinantsFit(int x, int y)
        {
            if (x > this.x || y > this.y)
                throw new InvalidDataException("x or y value are out of boundries");
                
        }
        public void SaveToFile(string path)
        {
            picture.Save(path, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
