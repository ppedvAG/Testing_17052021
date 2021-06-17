using Calculator;
using System;
using Xunit;

namespace Calulator.XUnitTests
{
    public class CalcTest
    {
        [Fact]
        public void Sum_N3_and_N4_results_N7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(-3, -4);

            //Assert
            Assert.Equal(-7, result);
        }

        [Theory]
        [InlineData(1, 4, 5)]
        [InlineData(7, 4, 11)]
        [InlineData(-1, 4, 3)]
        [InlineData(1, -4, -3)]
        [InlineData(0, 0, 0)]
        public void Sum_Tests(int a, int b, int expected)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            Assert.Equal(expected, result);
        }


    }
}
