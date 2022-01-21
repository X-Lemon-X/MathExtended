using System;
using MathExtended;

namespace MathExtendedConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MathExtended V3.1.0\n\n");

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

            Interval interval2 = new Interval(150, 200, Bracket.Open, Bracket.Close);
            QuadraticEquasion quadratic = new QuadraticEquasion(2,-200,0, interval2);

            CombinedEquasions cb = new CombinedEquasions();
            cb.AddEquasion(linear);
            cb.AddEquasion(linear2);           
            cb.AddEquasion(quadratic);

            Equasion equasion = new Equasion(linear);


            for (int i = -55; i < 205; i++)
            {
                Point po = cb.CalculateEquasion((double)i);

                double rad = Math.PI / 2.0;

                Point po2 = PointEquasions.MultiplyPointByMatrix(po, MatrixEquasion.MatrixRotationZ(new Matrix(), rad), 1);

                Point po3 = equasion.CalculateArgument(i);

                Console.WriteLine(MEConvertToString.FromPoint(po) + "  -> " + MEConvertToString.FromPoint(po2) + " -> "+ MEConvertToString.FromPoint(po3) );
            }


            Console.ReadLine();
        }
    }
}