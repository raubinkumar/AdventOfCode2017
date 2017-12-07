using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    [TestClass()]
    public class DayFourPassphrasesTest
    {
        [TestMethod]
        public void DayFourTestMethod1()
        {
            int count = DayFourPassphrases.GetValidPassphrases("Day4Data.txt");
            Assert.AreEqual(325, count);
        }

        [TestMethod]
        public void DayFourTestMethod2()
        {
            string[] data = new string[3] { "aa bb cc dd ee", "aa bb cc dd aa", "aa bb cc dd aaa" };
            int count = DayFourPassphrases.GetValidPassphrases(data);
            Assert.AreEqual(2, count);
        }
    }
}
