using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class ColoredCirclesAndPoint
{
    // Main unit
    static void Main()
    {
        Point userPoint = GetPointFromUser();
        Circle[] allCircles = GetCirclesFromFile("circles.txt");
        Circle[] coloredCircles = GetOverlayedCircles(allCircles);
        Circle[] affectedCircles = GetAffectedCircles(userPoint, coloredCircles);
        PrintCirclesInfo(affectedCircles, "Affected circles:");
    }

    // Daclaration of existing structures
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
        private string color;

        public Point Center { get { return center; } }
        public double Radius { get { return radius; } }
        public string Color { get { return color; } }

        public Circle(Point center, double radius)
        {
            this.center = center;
            this.radius = radius;
            this.color = "green";
        }

        public void SetRedColor()
        {
            color = "red";
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
        
        Circle[] circlesTemp = new Circle[allLines.Length];

        for (int i = 0; i < allLines.Length; i++)
        {
            string[] lineParts = allLines[i].Split(' ');

            double centerX = Convert.ToDouble(lineParts[0]);
            double centerY = Convert.ToDouble(lineParts[1]);
            
            double radius = Convert.ToDouble(lineParts[2]);

            Point center = new Point(centerX, centerY);

            circlesTemp[i] = new Circle(center, radius);
        }
        return circlesTemp;
    }

    static Circle[] GetOverlayedCircles(Circle[] circlesTemp)
    {
        for (int i = 0; i < circlesTemp.Length - 1; i++)
        {
            if (circlesTemp[i].Color == "green")
            {
                for (int j = i + 1; j < circlesTemp.Length; j++)
                {
                    if (circlesTemp[j].Color == "green")
                    {
                        if
                        (
                            Math.Pow((Math.Pow(circlesTemp[i].Center.X - circlesTemp[j].Center.X, 2) + 
                            Math.Pow(circlesTemp[i].Center.Y - circlesTemp[j].Center.Y, 2)), 0.5) <=
                            circlesTemp[i].Radius + circlesTemp[j].Radius
                        )
                        {
                            circlesTemp[i].SetRedColor();
                            circlesTemp[j].SetRedColor();
                        }
                    }
                }
            }
            
        }

        PrintCirclesInfo(circlesTemp.ToArray(), "Colored circles:");

        return circlesTemp.ToArray();
    }

    static Circle[] GetAffectedCircles(Point point, Circle[] circlesTemp)
    {
        List<Circle> affectedCirclesTemp = new List<Circle>();

        foreach (Circle circleTemp in circlesTemp)
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

    static void PrintCirclesInfo(Circle[] affectedCirclesTemp, string prompt)
    {
        Console.WriteLine(prompt);

        for (int i = 0; i < affectedCirclesTemp.Length; i++)
        {
            Console.WriteLine($"Circle № {i+1} -- center: ({affectedCirclesTemp[i].Center.X}, {affectedCirclesTemp[i].Center.Y}), " +
            $"radius: {affectedCirclesTemp[i].Radius}, color: {affectedCirclesTemp[i].Color}");
        }
    }
}