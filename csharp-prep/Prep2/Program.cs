using System;

class Program
{
    static string posOrNegGrade(int grade)
    {
        string posOrNeg;
        if (grade % 10 >= 7)
        {
            posOrNeg = "+";
        }
        else if (grade % 10 < 3)
        {
            posOrNeg = "-";
        }
        else
        {
            posOrNeg = "";
        }
        return posOrNeg;
    }
    static string printLetterGrade(int grade)
    {
        string letter;
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80 && grade < 90)
        {
            letter = "B";
        }
        else if (grade >= 70 && grade < 80)
        {
            letter = "C";
        }
        else if (grade >= 60 && grade < 70)
        {
            letter = "D";
        }
        else if (grade < 60)
        {
            letter = "F";
        }
        else
        {
            return "Error";
        }
        return letter;
    }
    static bool passOrFail(int grade)
    {
        if (grade >= 70)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static void Main(string[] args)
    {
        Console.Write("Grade (%): ");
        string strgrade = Console.ReadLine();
        int intGrade = int.Parse(strgrade);

        string letterGrade = printLetterGrade(intGrade);
        string posOrNeg = posOrNegGrade(intGrade);
        bool passFail = passOrFail(intGrade);

        if (intGrade >= 97 || letterGrade == "F")
        {
            Console.WriteLine($"Your grade {intGrade} is an {letterGrade}");
        }
        else
        {
            Console.WriteLine($"Your grade {intGrade} is an {letterGrade}{posOrNeg}");
        }
        if (passFail)
        {
            Console.WriteLine("Congrats! You passed the class!");
        }
        else
        {
            Console.WriteLine("You did not pass, try harder next time. ");
        }
    }
}
