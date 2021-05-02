using System;
using CalculatorLibrary;

namespace CalculatorProgram
{
    class Program
    {
        #region
        /*
        static void Main(string[] args)
        {
            // Declare variables and then initialize to zero.
            Double num_1 = 0; Double num_2 = 0;
            
            // Display the title as the C# cnsole calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            // Ask the user to type the first number.
            Console.WriteLine("Type a number, and then press Enter");
            num_1 = Convert.ToDouble(Console.ReadLine());

            // Ask the user to type the first number.
            Console.WriteLine("Type a number, and then press Enter");
            num_2 = Convert.ToDouble(Console.ReadLine());

            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiplication");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            // Use a switch statement to do the math.
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine($"Your result: {num_1} + {num_2} = " + (num_1 + num_2));
                    break;
                case "s":
                    Console.WriteLine($"Your result: {num_1} - {num_2} = " + (num_1 - num_2));
                    break;
                case "m":
                    Console.WriteLine($"Your result: {num_1} * {num_2} = " + (num_1 * num_2));
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor until they dos so.
                    while (num_2 == 0)
                    {
                        Console.WriteLine("Enter a non-zero divisor: ");
                        num_2 = Convert.ToDouble(Console.ReadLine());
                    }
                    Console.WriteLine($"Your result: {num_1} / {num_2} = " + (num_1 / num_2));
                    break;
            }
            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the calculator app...");
            Console.ReadKey();
        }
        */
        #endregion

        static void Main(string[] args)
        {
            bool endApp = false;
            // Display the title as the C# cnsole calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                // variables
                string numInput_1 = "";
                string numInput_2 = "";
                double result = 0;

                #region
                /*
                // Prompt the user for the first number.
                Console.Write("Type a number, then press Enter: ");
                numInput_1 = Console.ReadLine();

                double cleanNum_1 = 0;
                while (!double.TryParse(numInput_1, out cleanNum_1))
                {
                    Console.Write("This is not a vaid input. Please enter an integer value: ");
                }

                // Prompt the user for the second number.
                Console.Write("Type a number, then press Enter: ");
                numInput_2 = Console.ReadLine();

                double cleanNum_2 = 0;
                while (!double.TryParse(numInput_2, out cleanNum_2))
                {
                    Console.Write("This is not a vaid input. Please enter an integer value: ");
                }
                */
                #endregion

                string displayMessage = "Type a number, then press Enter: ";
                numInput_1 = PromptUserInput(displayMessage);
                numInput_2 = PromptUserInput(displayMessage);

                double cleanNum_1 = UserInputParser(numInput_1);
                double cleanNum_2 = UserInputParser(numInput_2);


                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum_1, cleanNum_2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            calculator.Finish();
            return;
        }

        public static string PromptUserInput(string msg)
        {

            Console.Write(msg);
            string input = Console.ReadLine();
            return input;
        }

        public static double UserInputParser(string num)
        {
            double cleanNum = 0;
            while (!double.TryParse(num, out cleanNum))
            {
                Console.Write("This is not a vaid input. Please enter an integer value: ");
            }
            return cleanNum;
        }
    }
}