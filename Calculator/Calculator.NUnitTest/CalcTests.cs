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

    }
}
