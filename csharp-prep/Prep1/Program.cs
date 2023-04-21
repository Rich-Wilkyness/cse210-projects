using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("First name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine($"{lastName}, {firstName} {lastName}");
    }
}