using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITeacher
{
    class Program
    {
        static void Main(string[] args)
        {
            askQuestion(); 
        }
        static  void askQuestion()
        {
            Random rand = new Random();
            int r_value = Convert.ToInt32(rand.Next(0, 9));
            int l_value = Convert.ToInt32(rand.Next(0, 9));
            Console.WriteLine($"How much is {r_value} times {l_value}");
            int product = r_value * l_value;
            int userInput = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out userInput);
                if (userInput == product)
                {
                    Console.WriteLine("Very Good");
                    askQuestion();
                }
                else if (userInput != product)
                {
                    Console.WriteLine("No. Please Try Again");
                }
            } while (userInput != product);
        }
    }
}
