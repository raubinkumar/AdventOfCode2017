using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    #region Part 1
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
        #endregion

        #region Part 2
        [TestMethod]
        public void DayFourTestMethod3()
        {
            int count = DayFourPassphrases.GetSecurePassphrases("Day4Data.txt");
            Assert.AreEqual(119, count);
        }

        [TestMethod]
        public void DayFourTestMethod4()
        {
            string[] data = new string[5] { "abcde fghij", "abcde xyz ecdab", "a ab abc abd abf abj", "iiii oiii ooii oooi oooo", "oiii ioii iioi iiio" };
            int count = DayFourPassphrases.GetSecurePassphrases(data);
            Assert.AreEqual(3, count);
        }
        #endregion
    }
}
