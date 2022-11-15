using System;
using Xunit;
using CronExpressionParser;

namespace CronExpressionParserTest
{
    public class TestCronExpressionParser
    {
        [Fact]
        public void TestNullExpressionException()
        {
            ExpressionParser expressionParser = new ExpressionParser(null);

            Assert.Throws<MissingFieldException>(() =>
            {
                expressionParser.InitiateParsing();                
            });
        }

        [Fact]
        public void TestInvalidCronExpressionError()
        {
            ExpressionParser expressionParser = new ExpressionParser("INVALID CRON EXPRESSION");
            var exception = Assert.Throws<FormatException>(() => expressionParser.InitiateParsing());
            Assert.Equal("Error: Expression has 3 parts.only 5 part are required.", exception.Message);
        }
    }
}
