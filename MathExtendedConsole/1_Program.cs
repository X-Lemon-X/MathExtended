﻿using System;
using MathExtended.Math_3D;
using MathExtended.Statistics;
using MathExtended.Pictures;

namespace MathExtendedConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //asfd

            Console.WriteLine("Working on it!");

            RawPhotoData rwd = new RawPhotoData(@"C:\Users\patdu\Desktop\test.jpg");

            ImageMatrixOperations imo = new ImageMatrixOperations();

            //rwd = imo.PrecessImageMask(rwd, new Matrix(mar), 1);

            //rwd = imo.PrecessImageMask(rwd, ImageManipulationMatrixs.GrayScale);
            //rwd = imo.PrecessImagePixels(rwd, ImageManipulationMatrixs.Sharpen);
            //rwd = imo.PrecessImagePixels(rwd, ImageManipulationMatrixs.EdgeDetection);
            //rwd.SaveToFile(@"C:\Users\patdu\Desktop\image1.png");

            //rwd = new RawPhotoData(@"C:\Users\patdu\Desktop\test.jpg");
            //rwd = imo.PrecessImagePixels(rwd, ImageManipulationMatrixs.Blur);
            //rwd.SaveToFile(@"C:\Users\patdu\Desktop\image2.png");

            //rwd = new RawPhotoData(@"C:\Users\patdu\Desktop\test.jpg");
            //rwd = imo.PrecessImageMask(rwd, ImageManipulationMatrixs.GrayScale);
            //rwd.SaveToFile(@"C:\Users\patdu\Desktop\image3.png");

            //rwd = new RawPhotoData(@"C:\Users\patdu\Desktop\test.jpg");

            rwd = imo.RemoveMetadata(rwd);


            rwd.SaveToFile(@"C:\Users\patdu\Desktop\image4.png");


            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        private void TestMath()
        {
            Console.WriteLine("MathExtended V3.1.0\n\n");
            Console.WriteLine("Point");
            Console.WriteLine(" x = 10, y =20,  z= 30");
            Point point = new Point(10, 20, 30);
            Console.WriteLine(MEConvertToString.FromPoint(point));
            Console.WriteLine("Vector");
            Vector vector = new Vector(point);
            Console.WriteLine(MEConvertToString.FromVector(vector));
            Console.WriteLine("Matrix");

            Interval interval = new Interval(-50, 100, Bracket.Close, Bracket.Open);
            LinearEquasion linear = new LinearEquasion(2, new Vector(), interval);

            interval = new Interval(100, 150, Bracket.Open, Bracket.Close);
            LinearEquasion linear2 = new LinearEquasion(-2, new Vector(), interval);

            Interval interval2 = new Interval(150, 200, Bracket.Open, Bracket.Close);
            QuadraticEquasion quadratic = new QuadraticEquasion(2, -200, 0, interval2);

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

                Console.WriteLine(MEConvertToString.FromPoint(po) + "  -> " + MEConvertToString.FromPoint(po2) + " -> " + MEConvertToString.FromPoint(po3));
            }

            double[] data = { 4, 84, 243558, 1245, 53, 24, 234, 89, 21, 6, 90965, 48, 546, 85, 74, 3, 9, 5, 1, 2, 1, 68, 8, 2, 78, 0, 2, 6, 9, 23, 6, 5, 7623, 234, 34, 6, 66 };
            DataForStatistics dataFor = new DataForStatistics(data);

            StatisticsData sd = new StatisticsData(dataFor);

            sd.GetAvarage();
            sd.GetStandardDiviation();
            DataForStatistics sdRet = sd.SortDataBubble();
            sd.GetMediana();
        }
    }
}