using System;
using MathExtended;

namespace MathExtendedConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MathExtended V2.0.1\n\n");

            Console.WriteLine("Point");
            Console.WriteLine(" x = 10, y =20,  z= 30");
            Point point = new Point(10,20,30);
            Console.WriteLine(ConvertToString.FromPoint(point));

            Console.WriteLine("Vector");
            Vector vector = new Vector(point);
            Console.WriteLine(ConvertToString.FromVector(vector));

            Console.WriteLine("Matrix");

            

            Console.ReadLine();
        }
    }
}
