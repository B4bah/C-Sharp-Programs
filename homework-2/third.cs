using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace Program
{
    class PointsInCircle
    {
        // Main unit
        static void Main()
        {
            Point[] allPoints = GetPointsFromFile("points.txt");
            Circle userCircle = GetCircleFromUser();
            bool userChoice = GetUserChoice();
            Point[] chosenPoints = FindOverlayedPoints(allPoints, userCircle, userChoice);
            PrintChosenPointsInfo(chosenPoints, userChoice);
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
        }

        // Declaration of functions
        static Point[] GetPointsFromFile(string filename)
        {
            string[] allLines = File.ReadAllLines(filename);
            Point[] pointsTemp = new Point[allLines.Length];

            for (int i = 0; i < allLines.Length; i++)
            {
                string[] lineParts = allLines[i].Split(' ');

                double pointX = Convert.ToDouble(lineParts[0]);
                double pointY = Convert.ToDouble(lineParts[1]);

                pointsTemp[i] = new Point(pointX, pointY);
            }
            return pointsTemp;
        }

        static Circle GetCircleFromUser()
        {
            Console.WriteLine("Enter the info about circle: coords of the center (x, y) and radius length");
            Console.Write("Enter the coords of the center, splitted by space:\n>>> ");
            string[] centerCoords = Console.ReadLine().Split(' ');
            double centerX = Convert.ToDouble(centerCoords[0]);
            double centerY = Convert.ToDouble(centerCoords[1]);
            Point center = new Point(centerX, centerY);

            Console.Write("Enter the radius length:\n>>> ");
            double radius = Convert.ToDouble(Console.ReadLine());

            return new Circle(center, radius);
        }

        static bool GetUserChoice()
        {
            Console.Write("Do you wanna see the info about overlayed point or the opposite? (y/n)\n>>> ");
            string choice = Console.ReadLine();

            if (choice == "y") return true;
            else return false;
        }

        static Point[] FindOverlayedPoints(Point[] points, Circle userCircle, bool userChoice)
        {
            List<Point> pointsOfChoice = new List<Point>();

            if (userChoice)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    if (Math.Pow(points[i].X - userCircle.Center.X, 2) + Math.Pow(points[i].Y - userCircle.Center.Y, 2) <= Math.Pow(userCircle.Radius, 2))
                    {
                        pointsOfChoice.Add(points[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < points.Length; i++)
                {
                    if (Math.Pow(points[i].X - userCircle.Center.X, 2) + Math.Pow(points[i].Y - userCircle.Center.Y, 2) > Math.Pow(userCircle.Radius, 2))
                    {
                        pointsOfChoice.Add(points[i]);
                    }
                }
            }

            return pointsOfChoice.ToArray();
        }

        static void PrintChosenPointsInfo(Point[] points, bool choice)
        {
            if (choice) Console.WriteLine("Overlayed points are");
            else Console.WriteLine("Not overlayed points are:");

            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine($"Point {i+1}: ({points[i].X}, {points[i].Y})");
            }
        }
    }
}