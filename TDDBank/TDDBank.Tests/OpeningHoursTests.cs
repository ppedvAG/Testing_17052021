using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TDDBank.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(2021, 6, 14, 10, 30, true)]//mo
        [DataRow(2021, 6, 14, 10, 29, false)]//mo
        [DataRow(2021, 6, 14, 10, 0, false)] //mo
        [DataRow(2021, 6, 14, 18, 59, true)] //mo
        [DataRow(2021, 6, 14, 19, 00, false)] //mo
        [DataRow(2021, 6, 19, 13, 0, true)] //sa
        [DataRow(2021, 6, 19, 16, 0, false)] //sa
        [DataRow(2021, 6, 20, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.AreEqual(result, oh.IsOpen(dt));
        }

        [TestMethod]
        public void can_call_IsNowOpen()
        {
            var oh = new OpeningHours();

            oh.IsNowOpen();
        }

        [TestMethod]
        public void IsNowOpen_mit_Fakes()
        {
            var oh = new OpeningHours();


            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 6, 14, 10, 29, 0);
                Assert.IsFalse(oh.IsNowOpen());

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 6, 14, 10, 30, 0);
                Assert.IsTrue(oh.IsNowOpen());

                System.IO.Fakes.ShimStreamReader.AllInstances.ReadLine = x => "Hallo";
                using (var sr = new StreamReader("C:\\temp\\lala.txt"))
                    Assert.AreEqual("Hallo", sr.ReadLine());

                //Assert.IsTrue(File.Exists("x:\\kerjhn.txt"));
            }
        }
    }
}
