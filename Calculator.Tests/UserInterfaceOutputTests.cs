using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    internal class UserInterfaceOutputTests
    {
        [TestMethod]
        [DataRow("5/0", "Illegal operation: division by zero.")]
        [DataRow("2--5", "Invalid expression.")]
        public void testExceptions(string input, string output)
        {
            Expression expression = new Expression(input);
            Assert.AreEqual(output, Program.CalculateResult(input));
        }

        [TestMethod]
        [DataRow("25/5", "5")]
        [DataRow("5/5*0", "0")]
        public void testIntegerOutputs(string input, string output)
        {
            Expression expression = new Expression(input);
            Assert.AreEqual(output, Program.CalculateResult(input));
        }

        [TestMethod]
        [DataRow("98/99", "0.98989898989899")]
        public void testDoubleOutputs(string input, string output)
        {
            Expression expression = new Expression(input);
            Assert.AreEqual(output, Program.CalculateResult(input));
        }
    }
}
