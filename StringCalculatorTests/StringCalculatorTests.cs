using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using StringCalculator;
using System;
using System.Security.Authentication;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1, 2", 3)]
        public void Add_GivenSimpleString_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        public void Add_GivenNewLine_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        public void Add_GivenDefinedDelimiter_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }

        [Theory]
        [InlineData("1,2,-1", "Negatives not allowed: -1")]
        [InlineData("//;\n1;-2;-4", "Negatives not allowed: -2,-4")]
        public void Add_ShouldThrowAnException_WhenNegativeNumbersAreUsed(string input, string expected)
        {
            Assert.Equal(expected, Assert.Throws<Exception>(() => Calculator.Add(input)).Message);
        }

        [Theory]
        [InlineData("//[*][%]\n1*2%3", 6)]
        public void Add_GivenMultipleDelimiter_ReturnsCorrectSum(string input, int expected)
        {
            Assert.Equal(expected, Calculator.Add(input));
        }
    }
}
