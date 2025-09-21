using System;
using System.IO;
using System.Linq;

class GradeClosestToAverage
{
    static double[] ReadGradesFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        return Array.ConvertAll(lines, Convert.ToDouble);
    }

    static double CalculateAverage(double[] grades)
    {
        return grades.Sum() / grades.Length;
    }

    static double FindClosestToAverage(double[] grades, double average)
    {
        Array.Sort(grades);
        double closestGrade = grades[0];
        double minDifference = Math.Abs(grades[0] - average);

        foreach (double grade in grades)
        {
            double currentDifference = Math.Abs(grade - average);
            if (currentDifference <= minDifference)
            {
                closestGrade = grade;
                minDifference = currentDifference;
            }
            else
            {
                break;
            }
        }

        return closestGrade;
    }

    static void DisplayResult(double closestGrade)
    {
        Console.WriteLine("The closest grade to the average is " + closestGrade);
    }

    static void Main()
    {
        double[] grades = ReadGradesFromFile("grades.txt");
        double average = CalculateAverage(grades);
        double closestGrade = FindClosestToAverage(grades, average);
        DisplayResult(closestGrade);
    }
}