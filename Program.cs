using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare local Variables
            int minValue = 0;
            int maxValue = 0;

            //App Information
            string appName = "NumberGuesser";
            string appVersion = "1.0.0";
            string appAuthor = "David Johnson";

            //Change text color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("App: {0}\nVersion: {1}\nby: {2}", appName, appVersion, appAuthor);
            Console.ResetColor();

            //Start the inputs
            Console.WriteLine("What is your name?: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Lets play a game, {0}", userName);
            Console.WriteLine("Choose two numbers and I will select a value between them, " +
                "you can take your guesses.\nMinimum value: ");
            string inputMinValue = Console.ReadLine();

            //Check to make sure minValue is a whole number
            bool minSuccess = Int32.TryParse(inputMinValue, out minValue);
            while (!minSuccess)
            {
                Console.WriteLine("The value that you have entered is not valid. Enter a whole number: ");
                inputMinValue = Console.ReadLine();
                minSuccess = Int32.TryParse(inputMinValue, out minValue);
            }


            Console.WriteLine("Maximum value: ");
            string inputMaxValue = Console.ReadLine();
            bool maxSuccess = Int32.TryParse(inputMaxValue, out maxValue);

            //Check to make sure max is higher number than min and value is an int
            while (!maxSuccess || maxValue < minValue)
            {
                Console.WriteLine("The value that you have entered is not valid.\n" +
                    "Enter a whole number greater than the minimum number: ");
                inputMaxValue = Console.ReadLine();
                maxSuccess = Int32.TryParse(inputMaxValue, out maxValue);
            }

            //Choose a random int between the two values
            int randomInt(int min, int max)
            {
                Random randomValue = new Random();
                return randomValue.Next(min, max);
            }
            int ranValue = randomInt(minValue, maxValue);
            Console.WriteLine("I've selected the random value...\n" +
                "Please make your guess: ");

            //Declare guess variables
            string guessValue = Console.ReadLine();
            int outGuess;
            bool isIntGuess = Int32.TryParse(guessValue, out outGuess);

            //Counter for guesses
            int i = 1;

            //Check the guessed value against the random value
            while (!isIntGuess || outGuess != ranValue)
            {
                while (outGuess > maxValue || outGuess < minValue)
                {
                    Console.WriteLine("Your guess was out of bounds. Try again: ");
                    guessValue = Console.ReadLine();
                    isIntGuess = Int32.TryParse(guessValue, out outGuess);
                }
                if (outGuess < ranValue)
                {
                    Console.WriteLine("Your guess was too low! Try a different number: ");
                    guessValue = Console.ReadLine();
                    isIntGuess = Int32.TryParse(guessValue, out outGuess);
                }
                if (outGuess > ranValue)
                {
                    Console.WriteLine("Your guess was too high! Try a different number: ");
                    guessValue = Console.ReadLine();
                    isIntGuess = Int32.TryParse(guessValue, out outGuess);
                }
                i++;
            }
            Console.WriteLine("You guessed the right number! The correct answer was: {0}", ranValue);
            Console.WriteLine("It took you {0} guess(es)", i);
        }
    }
}
