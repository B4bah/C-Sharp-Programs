using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace PointInTheCircles
{
    class Program
    {
        // Calculation unit
        static void Main()
        {
            Point userPoint = GetPointFromUser();
            Circle[] allCircles = GetCirclesFromFile("circles.txt");
            Circle[] affectedCircles = GetAffectedCircles(userPoint, allCircles);
            PrintAffectedCirclesInfo(affectedCircles);
        }

        // Declaration of existing structures
        struct Point
        {
            private double x;
            private double y;

            public double X { get { return x; } }
            public double Y { get { return y; } }

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        struct Circle
        {
            private Point center;
            private double radius;
            
            public Point Center { get { return center; } }
            public double Radius { get { return radius; } }

            public Circle(Point center, double radius)
            {
                this.center = center;
                this.radius = radius;
            }

            public double GetSquare()
            {
                return Math.PI * radius * radius;
            }
        }

        // Declaration of functions
        static Point GetPointFromUser()
        {
            Console.Write("Enter the coords (x, y) of the point, splitted by space:\n>>> ");
            string input = Console.ReadLine();
            string[] coords = input.Split(' ');

            double pointX = Convert.ToDouble(coords[0]);
            double pointY = Convert.ToDouble(coords[1]);

            return new Point(pointX, pointY);
        }

        static Circle[] GetCirclesFromFile(string filename)
        {
            string[] allLines = File.ReadAllLines(filename);
            
            Circle[] circles = new Circle[allLines.Length];

            for (int i = 0; i < allLines.Length; i++)
            {
                string[] lineParts = allLines[i].Split(' ');

                double centerX = Convert.ToDouble(lineParts[0]);
                double centerY = Convert.ToDouble(lineParts[1]);
                
                double radius = Convert.ToDouble(lineParts[2]);

                Point center = new Point(centerX, centerY);

                circles[i] = new Circle(center, radius);
            }
            return circles;
        }

        static Circle[] GetAffectedCircles(Point point, Circle[] circles)
        {
            List<Circle> affectedCirclesTemp = new List<Circle>();

            foreach (Circle circleTemp in circles)
            {
                if
                (
                    Math.Pow(point.X - circleTemp.Center.X, 2) + Math.Pow(point.Y - circleTemp.Center.Y, 2) <= 
                    Math.Pow(circleTemp.Radius, 2)
                )
                // then
                {
                    affectedCirclesTemp.Add(circleTemp);
                }
            }
            return affectedCirclesTemp.ToArray();
        }

        static void PrintAffectedCirclesInfo(Circle[] circles)
        {
            Console.WriteLine("Affected circles:");

            for (int i = 0; i < circles.Length; i++)
            {
                Console.WriteLine($"Circle № {i+1} -- center: ({circles[i].Center.X} {circles[i].Center.Y}), " +
                $"radius: {circles[i].Radius}, square: {circles[i].GetSquare():F2}");
            }
        }
    }

}