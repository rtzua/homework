using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class ExpressionValidationTests
    {
        [TestMethod]
        [DataRow("12.1+8")]
        [DataRow(@"10\2")]
        [DataRow("10+2=")]
        [DataRow("^10+2=")]
        public void testNotAllowedCharactersInExpression(string mathExpression)
        {
            var expression = new Expression(mathExpression);
            Assert.IsFalse(expression.IsValid(), $"{mathExpression} should not be a valid expression");
        }

        [TestMethod]
        [DataRow("10")]
        [DataRow("10+")]
        [DataRow("-5+1")]
        [DataRow("2+1*")]
        [DataRow("2+-1")]
        [DataRow("2++1")]
        [DataRow("/")]
        public void testIncorrectStructure(string mathExpression)
        {
            var expression = new Expression(mathExpression);
            Assert.IsFalse(expression.IsValid(), $"{mathExpression} should not be a valid expression");
        }

        [TestMethod]
        [DataRow(" 10 + 34  ")]
        [DataRow("10-1/2*10/10+11")]
        [DataRow("003-1/099999999")]
        public void testValidExpression(string mathExpression)
        {
            var expression = new Expression(mathExpression);
            Assert.IsTrue(expression.IsValid(), $"{mathExpression} should be a valid expression");
        }
    }
}
