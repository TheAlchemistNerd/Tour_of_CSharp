using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }
        public double DoOperation(double num_1, double num_2, string op)
        {
            double result = double.NaN;
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num_1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num_2);
            writer.WritePropertyName("Operation");

            switch (op)
            {
                case "a":
                    result = num_1 + num_2;
                    writer.WriteValue("Add");
                    break;
                case "m":
                    result = num_1 * num_2;
                    writer.WriteValue("Multiply");
                    break;
                case "s":
                    result = num_1 - num_2;
                    writer.WriteValue("Subract");
                    break;
                case "d":
                    if (num_2 != 0)
                        result = num_1 / num_2;
                    writer.WriteValue("Divide"); ;
                    break;
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
