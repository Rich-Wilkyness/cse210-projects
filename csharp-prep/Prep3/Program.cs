using System;

// 4 types of loops; while, do-while, for, foreach
/* do while loop example:
string response;

do
{
    Console.Write("Do you want to continue? ");
    response = Console.ReadLine();
} while (response == "yes");
*/
/* foreach loop example:
foreach (string color in colors)
{
    Console.WriteLine(color);
}
*/
/* Random number generator:
Random randomGenerator = new Random();
int number = randomGenerator.Next(1, 11);
*/
class Program
{
    static int checkGuess(int userGuess, int magicNumber)
    {
        if (userGuess == magicNumber)
        {
            Console.WriteLine("Congrats you guessed the right number! ");
            return 0;
        }
        else if (userGuess > magicNumber)
        {
            Console.WriteLine("Sorry the number is lower than your guess. ");
            return 1;
        }
        else if (userGuess < magicNumber)
        {
            Console.WriteLine("Sorry the number is higher than your guess. ");
            return 2;
        }
        else
        {
            Console.WriteLine("Invalid number. ");
            return 3;
        }
    }
    static void Main(string[] args)
    {
        string playAgain;
        do
        {


            // Generate a random number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            int checkedGuess = 1;
            int guessCounter = 0;
            do
            {
                // Get user guess
                Console.Write("Guess a number between 1 and 100: ");
                string strUserGuess = Console.ReadLine();
                int intUserGuess = int.Parse(strUserGuess);

                checkedGuess = checkGuess(intUserGuess, magicNumber);
                guessCounter++;

            } while (checkedGuess != 0);
            Console.WriteLine($"It took you {guessCounter} guesses. ");
            Console.Write("Would you like to play again? (Y/N) ");
            playAgain = Console.ReadLine();

        } while (playAgain.ToUpper() == "Y");
    }
}

