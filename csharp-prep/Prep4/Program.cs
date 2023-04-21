using System;
using System.Collections.Generic;
/*
List<string> words = new List<string>();
words.Add("phone");
Console.WriteLine(words.Count);
foreach (string word in words)
{
    Console.WriteLine(word);
}
OR YOU CAN DO A NORMAL FOR LOOP
for (int i = 0; i < words.Count; i++)
{
    Console.WriteLine(words[i]);
}
*/


class Program
{
    static int GetSumTotal(List<int> numbers)
    {
        int sumTotal = 0;
        foreach (int number in numbers)
        {
            sumTotal += number;
        }
        return sumTotal;
    }

    static int GetAverage(int sumTotal, int numberCount)
    {
        int average = sumTotal / numberCount;
        return average;
    }

    static int GetMaxNumber(List<int> numbers)
    {
        int maxNumber = -10000;
        foreach (int number in numbers)
        {
            if (maxNumber < number)
            {
                maxNumber = number;
            }
        }
        return maxNumber;
    }

    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        while (true)
        {
            Console.Write("Enter a number: ");
            string strUserNumber = Console.ReadLine();
            int intUserNumber = int.Parse(strUserNumber);
            if (intUserNumber == 0)
            {
                break;
            }
            numbers.Add(intUserNumber);
        }
        int sumTotal = GetSumTotal(numbers);
        int numberCount = numbers.Count;
        int average = GetAverage(sumTotal, numberCount);
        int maxNumber = GetMaxNumber(numbers);
        numbers.Sort();
        foreach (int number in numbers)
        {
            Console.WriteLine($"{number}");
        }
        Console.WriteLine($"sumTotal: {sumTotal}, average: {average}, max number: {maxNumber}. ");
    }
}