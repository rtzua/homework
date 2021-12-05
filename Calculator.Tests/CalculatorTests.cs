using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        [DataRow("1+2",   3)]
        [DataRow("2-5",  -3)]
        [DataRow("2*0 ",  0)]
        [DataRow("1/2", 0.5)]
        public void testSimpleExpressions(string input, double output)
        {
            var expression = new Expression(input);
            Assert.AreEqual(output, expression.GetResult());
        }

        [TestMethod]
        [DataRow("1+2/4*2-2", 0)]
        [DataRow("5-1+2*3/2", 7)]
        public void testOperationsOrder(string input, double output)
        {
            var expression = new Expression(input);
            Assert.AreEqual(output, expression.GetResult());
        }

        [TestMethod]
        [DataRow("2+3+2+3+2+3", 15)]
        [DataRow("10*2*10*2",  400)]
        public void testRepeatingElements(string input, double output)
        {
            var expression = new Expression(input);
            Assert.AreEqual(output, expression.GetResult());
        }

        [TestMethod]
        [DataRow("001+0020",   21)]
        [DataRow(" 20 000 - 10 000 ", 10000)]
        public void testGarbageCharacters(string input, double output)
        {
            var expression = new Expression(input);
            Assert.AreEqual(output, expression.GetResult());
        }

        [TestMethod]
        [DataRow("9223372036854775810/9223372036854775810", 1)]
        public void testNumbersOutOfIntegerRange(string input, double output)
        {
            var expression = new Expression(input);
            Assert.AreEqual(output, expression.GetResult());
        }

        [TestMethod]
        [DataRow("5/0")]
        public void testDivisionByZero(string input)
        {
            Exception expectedExcetpion = null;
            var expression = new Expression(input);
            try
            {
                expression.GetResult();
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            Assert.AreEqual("Illegal operation: division by zero.", expectedExcetpion.Message);       
        }

    }
}
