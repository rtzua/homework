using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Expression
    {
        private string Input;

        public Expression(string input)
        {
            Input = input;
            CleanSpaces();
        }

        public bool IsValid()
        {
            var a = Regex.IsMatch(this.Input, @"^(\d+[\*\+\-\/])+\d+$");
            return a;
        }


        public double GetResult()
        {
            if (!IsValid())
            {
                throw new FormatException("The input value is invalid.");
            }

            List<string> NumbersAndOperations = Split();

            double result = Convert.ToDouble(NumbersAndOperations[0]);

            int index = IndexOfCurrentOperation(NumbersAndOperations);

            while (index > -1)
            {
                result = CompleteBinaryOperation(Convert.ToDouble(NumbersAndOperations[index - 1]), Convert.ToDouble(NumbersAndOperations[index + 1]), NumbersAndOperations[index]);
                NumbersAndOperations[index - 1] = result.ToString();
                NumbersAndOperations.RemoveAt(index);
                NumbersAndOperations.RemoveAt(index);
                index = IndexOfCurrentOperation(NumbersAndOperations);
            }

            return result;
        }

        private List<string> Split()
        {
            return Regex.Split(Input, @"(\d+)([\*+-/])").Where(s => s != string.Empty).ToList();
        }

        private void CleanSpaces()
        {
            this.Input = Regex.Replace(this.Input, @"\s", "");
        }

        private int IndexOfTopPriorityOperation(List<string> input)
        {
            int divisionInd = input.IndexOf("/");
            int multiplicationInd = input.IndexOf("*");

            if (divisionInd == -1 ^ multiplicationInd == -1)
            {
                return Math.Max(divisionInd, multiplicationInd);
            }

            else
            {
                return Math.Min(divisionInd, multiplicationInd);
            }
        }

        private int IndexOfCurrentOperation(List<string> input)
        {
            int topPriority = IndexOfTopPriorityOperation(input);
            if (topPriority != -1)
            {
                return topPriority;
            }
            else
            {
                if (input.Count > 1)
                {
                    return 1;
                }
            }
            return -1;
        }

        private static double CompleteBinaryOperation(double var1, double var2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return var1 + var2;
                case "-":
                    return var1 - var2;
                case "*":
                    return var1 * var2;
                case "/":
                    if (var2 != 0)
                    {
                        return var1 / var2;
                    }
                    else
                    {
                        throw new InvalidOperationException("Illegal operation: division by zero.");
                    }

                default:
                    {
                        throw new InvalidOperationException(operation + " is not a valid operator.");
                    }
            }
        }
    }
}
