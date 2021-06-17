using NUnit.Framework;
using System;

namespace Calculator.NUnitTest
{
    [TestFixture]
    public class CalcTests
    {
        [Test]
        public void Sum_3_and_12_result_15()
        {
            var calc = new Calc();

            var result = calc.Sum(3, 12);

            //Assert.AreEqual(15, result);
            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        [Category("Data Driven")]
        [TestCase(1, 4, 5)]
        [TestCase(7, 4, 11)]
        [TestCase(-1, 4, 3)]
        [TestCase(1, -4, -3)]
        [TestCase(0, 0, 0)]
        public void Sum_Tests(int a, int b, int expected)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void Sum_MAX_and_1__throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MinValue, -1));

        }

    }
}
