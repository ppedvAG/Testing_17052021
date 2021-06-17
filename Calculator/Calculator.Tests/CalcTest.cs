using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTest
    {

        [TestMethod]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Sum_N3_and_N4_results_N7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(-3, -4);

            //Assert
            Assert.AreEqual(-7, result);
        }

        [TestMethod]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Sum_MAX_and_1__throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }
    }
}
