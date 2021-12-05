using System;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a math expression. Integer numbers and the following expressions allowed: +, -, *, /");
                var input = Console.ReadLine();
                Console.WriteLine(CalculateResult(input));
                Console.WriteLine();
            }
        }

        public static string CalculateResult(string input)
        {
            var expression = new Expression(input);

            if (expression.IsValid())
            {
                try
                {
                    return expression.GetResult().ToString();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

            return "Invalid expression.";
        }
    }
}
