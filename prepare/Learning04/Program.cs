using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Jerry", "Math");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment mathAssignment1 = new MathAssignment("Mike", "Division", "7.3", "8-19");
        Console.WriteLine(mathAssignment1.GetSummary());
        Console.WriteLine(mathAssignment1.GetHomeworkList());

        WritingAssignment writingAssignment1 = new WritingAssignment("Mary", "European History", "The Causes of World War II by Mary Waters");
        Console.WriteLine(writingAssignment1.GetSummary());
        Console.WriteLine(writingAssignment1.GetWritingInformation());
    }
}