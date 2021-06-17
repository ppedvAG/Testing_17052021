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
        [TestCategory("Data Driven")]
        [DataRow(1, 4, 5)]
        [DataRow(7, 4, 11)]
        [DataRow(-1, 4, 3)]
        [DataRow(1, -4, -3)]
        [DataRow(0, 0, 0)]
        public void Sum_Tests(int a, int b, int expected)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Sum_MAX_and_1__throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }


        [TestMethod]
        public void Calc_IstEsHeiﬂ()
        {
            var calc = new Calc();

            Assert.IsTrue(calc.IstEsHeiﬂ(20));
            Assert.IsTrue(calc.IstEsHeiﬂ(21));
            Assert.IsTrue(calc.IstEsHeiﬂ(int.MaxValue));

            Assert.IsFalse(calc.IstEsHeiﬂ(19));
            Assert.IsFalse(calc.IstEsHeiﬂ(0));
            Assert.IsFalse(calc.IstEsHeiﬂ(int.MinValue));
        }
    }
}
