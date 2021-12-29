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
            Console.WriteLine(MEConvertToString.FromPoint(point));

            Console.WriteLine("Vector");
            Vector vector = new Vector(point);
            Console.WriteLine(MEConvertToString.FromVector(vector));

            Console.WriteLine("Matrix");


            Interval interval = new Interval(-50,100, Bracket.Close, Bracket.Open);
            LinearEquasion linear = new LinearEquasion(2, new Vector(),interval);

            interval = new Interval(100, 150, Bracket.Open, Bracket.Close);
            LinearEquasion linear2 = new LinearEquasion(-2, new Vector(), interval);

            interval = new Interval(150, 200, Bracket.Open, Bracket.Close);
            QuadraticEquasion quadratic = new QuadraticEquasion(2,-200,0, interval);

            CombinedEquasions cb = new CombinedEquasions();
            cb.AddEquasion(linear);
            cb.AddEquasion(linear2);
            cb.AddEquasion(quadratic);


            for (int i = -55; i < 205; i++)
            {
                var po = cb.CalculateEquasion((double)i);
                Console.WriteLine(MEConvertToString.FromPoint(po));
            }
            
            


            Console.ReadLine();
        }
    }
}
