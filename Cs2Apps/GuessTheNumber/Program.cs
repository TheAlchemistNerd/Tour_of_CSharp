using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            System.IO.StreamWriter sw = new System.IO.StreamWriter("debug.txt");
            sw.AutoFlush = true;
            Console.SetOut(sw);
            */
            do
            {
                int numberToGuess = new Random().Next(1, 1000);
                int userGuess = 0;
                Console.WriteLine("Guess a number between 1 and 1000");
                while (true)
                {
                    userGuess = promptUserGuess();

                    if (userGuess > numberToGuess)
                    {
                        Console.WriteLine("Too high. Try again");
                    }
                    else if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("Too low. Try again");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations you guessed the number");
                        break;
                    }
                }
                Console.WriteLine("Would you play to play again? Y or N");
            } while (Console.ReadLine().ToLower() == "y");
        }

        public static int promptUserGuess()
        {
            int userGuess = 0;

            try
            {
                userGuess = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("You did not enter a valid guess");
                Console.WriteLine($"Error: {e.Message}");
                userGuess = promptUserGuess();
            }

            return userGuess;
        }
    }
}
