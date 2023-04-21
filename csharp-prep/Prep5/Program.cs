using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("User Name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Favorite Number: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }

    static double GetSquareNumber(int number)
    {
        Console.WriteLine($"{number}");
        double squaredNumber = Math.Pow(number, 2);
        Console.WriteLine($"{squaredNumber}");
        return squaredNumber;
    }

    static void DisplayResults(string userName, double userNumberSquared)
    {
        Console.WriteLine($"user name: {userName}, user favorite number squared: {userNumberSquared} ");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        double squaredNumber = GetSquareNumber(userNumber);
        DisplayResults(userName, squaredNumber);

    }
}