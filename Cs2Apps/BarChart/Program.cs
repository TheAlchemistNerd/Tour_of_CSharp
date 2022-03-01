using System;
using System.Collections.Generic;


namespace BarChart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The application accepts user input and prints\nthe horizontal barcharts. Below is an illustration");
            var testList = new List<int> { 3, 5, 8, 13, 21 };
            printBarChart(testList);
            Console.WriteLine();

            // Accept the user input
            var numbers = getUserInput();

            // print the charts
            printBarChart(numbers);

            Console.ReadKey();
        }

        public static List<int> getUserInput()
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter 3 numbers between 1 and 30");
            for (int i = 0; i < 3; i++)
            {
                int _value = Convert.ToInt32(Console.ReadLine());
                numbers.Add(_value);
            }
            return numbers;
        }

        public static void printBarChart(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                for (int i = 0; i < number; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}