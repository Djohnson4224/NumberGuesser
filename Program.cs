using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            //App variables
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
            int minValue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Maximum value: ");
            int maxValue = Convert.ToInt32(Console.ReadLine());
            
            //Choose a random int between the two values
            int randomInt(int min, int max)
            {
                Random randomValue = new Random();

                return randomValue.Next(min, max);
            }
            int ranValue = randomInt(minValue,maxValue);
            Console.WriteLine("I've selected the random value...\n" +
                "Please make your guess: ");
            int guessValue = Convert.ToInt32(Console.ReadLine());
            //Counter for guesses
            int i = 1;
            //Check the guessed value against the random value
            while (guessValue != ranValue)
            {
                
                if (guessValue < ranValue)
                {
                    Console.WriteLine("Sorry, your guess was too low! Try again: ");
                    guessValue = Convert.ToInt32(Console.ReadLine());
                    
                }
                else if (guessValue > ranValue)
                {
                    Console.WriteLine("Sorry, your guess was too high! Try again: ");
                    guessValue = Convert.ToInt32(Console.ReadLine());
                    
                }
                i++;
            }
            Console.WriteLine("You guessed the right number! The correct answer was: {0}", ranValue);
            Console.WriteLine("It took you {0} guess(es)", i);
        }
    }
}
