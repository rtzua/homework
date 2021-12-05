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
            this.Input = Regex.Replace(input, @"\s", "");
        }

        public bool IsValid()
            => Regex.IsMatch(this.Input, @"^(\d+[\*\+\-\/])+\d+$");


        public double GetResult()
        {
            if (!IsValid())
            {
                throw new FormatException("The input value is invalid.");
            }

            List<string> numsAndOps = GetExpressionElements();

            double result = Convert.ToDouble(numsAndOps[0]);

            int index = IndexOfCurrentOperation(numsAndOps);

            while (index > -1)
            {
                result = CompleteBinaryOperation(Convert.ToDouble(numsAndOps[index - 1]), Convert.ToDouble(numsAndOps[index + 1]), numsAndOps[index]);
                numsAndOps[index - 1] = result.ToString();
                numsAndOps.RemoveAt(index);
                numsAndOps.RemoveAt(index);
                index = IndexOfCurrentOperation(numsAndOps);
            }

            return result;
        }

        private List<string> GetExpressionElements()
            => Regex.Split(Input, @"(\d+)([\*+-/])").Where(s => s != string.Empty).ToList();

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
