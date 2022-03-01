using System;

namespace AITeacher
{
    class Program
    {
        static void Main(string[] args)
        {
            generateQuiz();
        }
        static void generateQuiz()
        {
            Random number = new Random();
            int prod_one = Convert.ToInt32(number.Next(0, 9));
            int prod_two = Convert.ToInt32(number.Next(0, 9));
            Console.WriteLine($"How much is {prod_one} times {prod_two}");
            int product = prod_one * prod_two;
            int studentResponse = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out studentResponse);
                if (studentResponse == product)
                {
                    Console.WriteLine("Very Good");
                    generateQuiz();
                }
                else if (studentResponse != product)
                {
                    Console.WriteLine("No. Please Try Again");
                }
            } while (studentResponse != product);
        }
    }
}
