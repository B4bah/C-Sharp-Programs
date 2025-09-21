using System;

class TheMiddleGrade
{
    static double GetGradeFromUser(string prompt)
    {
        Console.Write(prompt);
        return Convert.ToDouble(Console.ReadLine());
    }

    static double FindMiddleGrade(double grade1, double grade2, double grade3)
    {
        if ((grade1 >= grade2 && grade2 >= grade3) || (grade1 <= grade2 && grade2 <= grade3))
            return grade2;
        else if ((grade2 >= grade1 && grade1 >= grade3) || (grade2 <= grade1 && grade1 <= grade3))
            return grade1;
        else
            return grade3;
    }

    static void DisplayResult(double middleGrade)
    {
        Console.WriteLine("The middle score is " + middleGrade);
    }

    static void Main(string[] args)
    {
        double grade1 = GetGradeFromUser("Enter 3 student's grades. The first one:\n>>> ");
        double grade2 = GetGradeFromUser("The second one:\n>>> ");
        double grade3 = GetGradeFromUser("The third one:\n>>> ");

        double middleGrade = FindMiddleGrade(grade1, grade2, grade3);
        
        DisplayResult(middleGrade);
    }
}